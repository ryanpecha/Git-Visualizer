using System.Diagnostics;
using System.Management.Automation.Runspaces;
using System.Text.Json;
using System;
using System.Runtime.InteropServices;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Management.Automation;
using GitVisualizer.UI.UI_Forms;
using System.Windows.Forms.VisualStyles;
using System.Text.RegularExpressions;

namespace GitVisualizer;

public static class GitAPI
{

    public static Github github { get; set; }

    /// <summary> pointer to the live commit </summary>
    public static Branch? liveBranch { get; private set; }

    /// <summary> currently checked out commit </summary>
    public static Commit? liveCommit { get; private set; }

    /// <summary> currently tracked local repository </summary>
    public static RepositoryLocal? liveRepository { get; private set; }

    // url -> remoteRepo
    private static Dictionary<string, RepositoryRemote> remoteRepositories;
    // dirPath -> localRepo;
    private static Dictionary<string, RepositoryLocal> localRepositories;
    // url -> list<localRepo>
    private static Dictionary<string, HashSet<RepositoryLocal>> remoteBackedLocalRepositories;

    public static int? commitsAhead { get; private set; } = 0;
    public static int? commitsBehind { get; private set; } = 0;

    /// <summary> GitAPI initialization </summary>
    static GitAPI()
    {
        Debug.WriteLine("INITIALIZING GIT API");

        // ref to program GitHub api
        github = Program.Github;

        //
        remoteRepositories = new Dictionary<string, RepositoryRemote>();
        localRepositories = new Dictionary<string, RepositoryLocal>();
        remoteBackedLocalRepositories = new Dictionary<string, HashSet<RepositoryLocal>>();
    }

    public class Scanning
    {
        public static void scanForLocalRepos(Action? callback)
        {
            localRepositories.Clear();
            remoteBackedLocalRepositories.Clear();
            Debug.WriteLine("scanDirs()");
            foreach (LocalTrackedDir trackedDir in GVSettings.data.trackedLocalDirs)
            {
                Debug.WriteLine($"scanning dir {trackedDir.path}");
                string dirPath = trackedDir.path;
                bool recursive = trackedDir.recursive;
                SearchOption searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                if (!Directory.Exists(dirPath))
                {
                    continue;
                }
                string[] gitFolderPaths = Directory.GetDirectories(dirPath, ".git", searchOption);
                foreach (string gitFolderPath in gitFolderPaths)
                {
                    // getting parent folder of .git folder
                    DirectoryInfo? repoDirInfo = Directory.GetParent(gitFolderPath);
                    // skipping null info
                    if (repoDirInfo == null)
                    {
                        continue;
                    }
                    // getting repo folder abs path
                    string repoDirPath = repoDirInfo.FullName;
                    string repoName = repoDirInfo.Name;
                    RepositoryLocal newLocalRepo = new RepositoryLocal(repoName, repoDirPath);

                    // skipping already loaded local repos
                    if (localRepositories.ContainsKey(newLocalRepo.dirPath))
                    {
                        continue;
                    }
                    localRepositories[newLocalRepo.dirPath] = newLocalRepo;
                    // skipping remote refs for local only repos
                    string? remoteURL = newLocalRepo.getRemoteURL();
                    if (remoteURL == null)
                    {
                        continue;
                    }
                    if (remoteBackedLocalRepositories.ContainsKey(remoteURL))
                    {
                        // skipping already tracked remote backed local repos
                        remoteBackedLocalRepositories[remoteURL].Add(newLocalRepo);
                        continue;
                    }
                    // initalizing with single local repo
                    remoteBackedLocalRepositories[remoteURL] = [newLocalRepo];
                }
            }
            if (callback != null)
            {
                callback();
            }
        }


        //
        public static async Task scanForRemoteReposAsync(Action? callback)
        {
            Debug.WriteLine("scanRemotesAsync()");
            List<RepositoryRemote>? newRemoteRepos = await github.ScanReposAsync();
            if (newRemoteRepos != null)
            {
                foreach (RepositoryRemote newRemoteRepo in newRemoteRepos)
                {
                    // skipping already tracked remotes
                    if (remoteRepositories.ContainsKey(newRemoteRepo.cloneURL))
                    {
                        continue;
                    }
                    remoteRepositories[newRemoteRepo.cloneURL] = newRemoteRepo;
                }
            }
            if (callback != null)
            {
                callback();
            }
        }


        //
        public static async void scanForAllRepos(Action? callback)
        {
            Debug.WriteLine("scanAllAsync()");
            // loading local repositories
            scanForLocalRepos(null);
            // loading remote repositories
            await scanForRemoteReposAsync(null);
            //
            if (GVSettings.data.liveRepostoryPath != null)
            {
                if (liveRepository == null)
                {
                    if (localRepositories.ContainsKey(GVSettings.data.liveRepostoryPath))
                    {
                        RepositoryLocal curRepo = localRepositories[GVSettings.data.liveRepostoryPath];
                        Actions.LocalActions.setLiveRepository(curRepo);
                    }
                }
            }
            //
            if (callback != null)
            {
                callback();
            }
        }
    }

    /// <summary> Git Actions </summary>
    public static class Actions
    {
        public static class RemoteActions
        {

            public static void untrackRemoteRepos(Action callback)
            {
                remoteRepositories.Clear();
                callback();
            }

            public readonly static string description_deleteRemoteRepository = "";
            public static void deleteRemoteRepository()
            {
                // TODO delete
            }


            public readonly static string description_createRemoteRepository = "";
            public static async void createRemoteRepository(RepositoryLocal localRepo, Action callback)
            {
                string cloneURL = await github.CreateRepo(localRepo.title);

                RepositoryLocal? curLiveRepo = liveRepository;
                LocalActions.setLiveRepository(localRepo);

                Tuple<string?, string?> curShorthashAndBranch = Getters.getLiveCommitShortHashAndBranch();

                string? curShortHash = curShorthashAndBranch.Item1;
                string? curBranchName = curShorthashAndBranch.Item2;

                Debug.WriteLine($"createRemoteRepository IN PROGRESS cloneURL={cloneURL} curShortHash={curShortHash} curBranchName={curBranchName}");

                if (cloneURL != null)
                {
                    string com = $"cd '{localRepo.dirPath}'; ";
                    com += $"git remote add origin https://{cloneURL}.git; ";
                    if (curBranchName != null)
                    {
                        com += $"git branch -M {curBranchName}; ";
                        com += $"git push -u origin {curBranchName}; ";
                    }
                    else if (curShortHash != null)
                    {
                        com += $"git branch -M main; ";
                        com += $"git push -u origin main; ";
                    }
                    ShellComRes comResult = Shell.exec(com);
                }

                remoteBackedLocalRepositories.Clear();
                localRepositories.Clear();
                remoteRepositories.Clear();

                Scanning.scanForAllRepos(callback);

                if (curLiveRepo != null)
                {
                    foreach (KeyValuePair<string, RepositoryLocal> localrepoPair in localRepositories)
                    {
                        string repoPath = localrepoPair.Key;
                        if (repoPath == curLiveRepo.dirPath)
                        {
                            LocalActions.setLiveRepository(localrepoPair.Value);
                        }
                    }
                }

                callback();
            }


            public readonly static string description_addLocalBranchToRemote = "";
            public static void addLocalBranchToRemote(Branch branch)
            {
                if (liveRepository != null)
                {
                    string com = $"cd '{liveRepository.dirPath}'; ";
                    com += $"git push -u {branch.title}";
                    ShellComRes comResult = Shell.exec(com);
                }
            }


            public readonly static string description_deleteRemoteBranch = "";
            public static void deleteRemoteBranch(Branch branch)
            {

            }


            public readonly static string description_cloneRemoteRepository = "";
            public static void cloneRemoteRepository(RepositoryRemote repositoryRemote, Action? callback)
            {
                Debug.WriteLine("CLONING : " + repositoryRemote.cloneURL);
                // TODO check that .git folder and repo exist
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                DialogResult fdResult = dialog.ShowDialog();
                if (fdResult == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    string cloneDirPath = Path.GetFullPath(dialog.SelectedPath);
                    string clonedRepoPath = cloneDirPath + "\\" + repositoryRemote.title;
                    //
                    string com = $"cd '{cloneDirPath}'; ";
                    com += $"git clone https://{repositoryRemote.cloneURL}";
                    ShellComRes comResult = Shell.exec(com);
                    // TODO check for command success
                    LocalActions.trackDirectory(clonedRepoPath, true, callback);
                }
            }


            public readonly static string description_sync = "";
            public static void sync()
            {
                // fetch and pull
                if (liveCommit != null)
                {
                    string com = $"cd '{liveCommit.localRepository.dirPath}'; ";
                    com += $"git fetch --all";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                    com = $"cd '{liveCommit.localRepository.dirPath}'; ";
                    com += $"git pull --all -p";
                    result = Shell.exec(com);
                    if (liveBranch != null)
                    {
                        // TODO check for command success
                        com = $"cd '{liveCommit.localRepository.dirPath}'; ";
                        com += $"git push origin {liveBranch.title}:{liveBranch.title}";
                        result = Shell.exec(com);
                        // TODO check for command success
                    }
                    Getters.setCommitsAheadAndBehind();
                }
            }
        }


        /// <summary> actions on the local filesystem within the currently checked-out commit </summary>
        public static class LocalActions
        {

            public readonly static string description_setLiveRepository = "";
            public static void setLiveRepository(RepositoryLocal repositoryLocal)
            {
                if (!ReferenceEquals(repositoryLocal, liveRepository))
                {
                    // TODO check that .git folder and repo exist
                    string com = $"cd '{repositoryLocal.dirPath}'; ";
                    com += $"git init '{repositoryLocal.dirPath}'";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                    liveRepository = repositoryLocal;
                    // set commit to currently checked out repo commit
                    Getters.getCommitsAndBranches();
                    // updating settings
                    GVSettings.data.liveRepostoryPath = liveRepository.dirPath;
                    GVSettings.saveSettings();
                }
                Getters.setCommitsAheadAndBehind();
            }


            public readonly static string description_checkoutCommit = "";
            public static void checkoutCommit(Commit commit)
            {
                if (!ReferenceEquals(commit, liveCommit))
                {
                    // TODO check that commit exists
                    string com = $"cd '{commit.localRepository.dirPath}'; ";
                    com += $"git checkout {commit.longCommitHash}";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                    liveCommit = commit;
                    liveBranch = null;
                }
                Getters.setCommitsAheadAndBehind();
            }


            public readonly static string description_checkoutBranch = "";
            public static void checkoutBranch(Branch branch)
            {
                if (!ReferenceEquals(branch.commit, liveCommit))
                {
                    // TODO check that branch exists and points to a valid commit
                    string com = $"cd '{branch.commit.localRepository.dirPath}'; ";
                    com += $"git checkout {branch.title}";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                    liveCommit = branch.commit;
                    liveBranch = branch;
                }
                Getters.setCommitsAheadAndBehind();
            }


            public readonly static string description_createLocalBranch = "";
            public static Branch createLocalBranch(string title, Commit commit)
            {
                // TODO check that branch does not exist
                string com = $"cd '{commit.localRepository.dirPath}'; ";
                com += $"git checkout -b {title} {commit.longCommitHash}";
                ShellComRes result = Shell.exec(com);
                // TODO check for command success
                Branch branch = new Branch(title, commit);
                // TODO add new branch to global branch
                liveCommit = branch.commit;
                return branch;
            }


            public readonly static string description_deleteBranchLocal = "";
            public static void deleteBranchLocal(Branch branch)
            {
                if (!ReferenceEquals(branch.commit, liveCommit))
                {
                    // TODO check that branch exists and points to a valid commit
                    string com = $"cd '{branch.commit.localRepository.dirPath}'; ";
                    com += $"git branch -D {branch.title}";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                    com = $"cd '{branch.commit.localRepository.dirPath}'; ";
                    com += $"git push origin -d {branch.title}";
                    result = Shell.exec(com);
                }
            }

            public readonly static string description_merge = "";
            public static void merge()
            {

            }


            public readonly static string description_trackDirectory = "";
            public static void trackDirectory(string dirPath, bool recursive, Action? callback)
            {
                foreach (LocalTrackedDir trackedDir in GVSettings.data.trackedLocalDirs)
                {
                    if (trackedDir.path == dirPath)
                    {
                        trackedDir.recursive = recursive;
                        return;
                    }
                }
                LocalTrackedDir newTrackedDir = new LocalTrackedDir(dirPath, recursive);
                GVSettings.data.trackedLocalDirs.Add(newTrackedDir);
                GVSettings.saveSettings();
                Scanning.scanForLocalRepos(callback);
            }

            public readonly static string description_untrackDirectory = "";
            public static void untrackDirectory(LocalTrackedDir trackedDir, Action? callback)
            {
                Debug.WriteLine($"UNTRACKING {trackedDir.path}");
                if (GVSettings.data.trackedLocalDirs.Contains(trackedDir))
                {
                    Debug.WriteLine($"UNTRACKING CONTAINS {trackedDir.path}");
                    GVSettings.data.trackedLocalDirs.Remove(trackedDir);
                }
                GVSettings.saveSettings();
                Scanning.scanForLocalRepos(callback);
            }

            public readonly static string description_userSelectTrackDirectory = "";
            public static void userSelectTrackDirectory(bool recursive, Action? callback)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    string fullPath = Path.GetFullPath(dialog.SelectedPath);
                    trackDirectory(fullPath, recursive, callback);
                }
            }

            public readonly static string description_getTrackedDirs = "";
            public static List<LocalTrackedDir> getTrackedDirs()
            {
                return GVSettings.data.trackedLocalDirs;
                //List<string> trackedDirs = GVSettings.data.trackedLocalDirs.Select(o => o.path).ToList();
                //return trackedDirs;
            }

            public readonly static string description_createLocalRepository = "";
            public static void createLocalRepository(Action? callback)
            {
                // TODO check that .git folder and repo exist
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                DialogResult fdResult = dialog.ShowDialog();
                if (fdResult == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    string repoDirPath = Path.GetFullPath(dialog.SelectedPath);
                    string? repoName = Path.GetDirectoryName(repoDirPath);
                    if (repoName == null)
                    {
                        return;
                    }
                    //
                    string com = $"cd '{repoDirPath}'; ";
                    com += $"git init --initial-branch=main; git add -A; git commit -m 'initalizing {repoName}'";
                    ShellComRes comResult = Shell.exec(com);
                    // TODO check for command success
                    trackDirectory(repoDirPath, true, callback);
                }
            }

            public readonly static string description_clean = "";
            public static void clean()
            {
                if (liveRepository != null)
                {
                    string com = $"cd '{liveRepository.dirPath}'; ";
                    com += $"git clean -fdx";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                }
            }

            public readonly static string description_stageChanges = "";
            public static void stageChange(string fpath)
            {
                // stage file changes to commit
                if (liveRepository != null)
                {
                    string com = $"cd '{liveRepository.dirPath}'; ";
                    com += $"git add '{fpath}'";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                    Debug.WriteLine($"stageChange successful={result.success} fpath=${fpath} dirpath={liveRepository.dirPath} errmsg={result.errmsg}");
                    if (result.psObjects != null)
                    {
                        foreach (PSObject pso in result.psObjects)
                        {
                            Debug.WriteLine(pso.ToString());
                        }
                    }
                }
            }

            public readonly static string description_unStageChanges = "";
            public static void unStageChange(string fpath)
            {
                // unstage file changes to commit
                if (liveRepository != null)
                {
                    string com = $"cd '{liveRepository.dirPath}'; ";
                    com += $"git reset '{fpath}'";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                    Debug.WriteLine($"unStageChange successful={result.success}");
                    if (result.psObjects != null)
                    {
                        foreach (PSObject pso in result.psObjects)
                        {
                            Debug.WriteLine(pso.ToString());
                        }
                    }

                }
            }

            public readonly static string description_commitStagedChanges = "";
            public static void commitStagedChanges(string message)
            {
                // unstage all staged changes
                if (liveRepository != null)
                {
                    Debug.Write($"COMMITTING : message={message}");
                    string com = $"cd '{liveRepository.dirPath}'; ";
                    com += $"git commit -m '{message}'";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                }
                Getters.setCommitsAheadAndBehind();
            }

            public readonly static string description_unstageAllStagedChanges = "";
            public static void unstageAllStagedChanges()
            {
                // unstage all staged changes
                if (liveRepository != null)
                {
                    string com = $"cd '{liveRepository.dirPath}'; ";
                    com += $"git reset";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                }
            }

            public readonly static string description_stageAllUnstagedChanges = "";
            public static void stageAllUnstagedChanges()
            {
                // stage all changed files
                if (liveRepository != null)
                {
                    string com = $"cd '{liveRepository.dirPath}'; ";
                    com += $"git add -u";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                }
            }

            public readonly static string description_revertUnstagedChange = "";
            public static void revertUnstagedChange(string fpath)
            {
                // reset file to state without any changes
                if (liveRepository != null)
                {
                    string com = $"cd '{liveRepository.dirPath}'; ";
                    com += $"git checkout '{fpath}'";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                }
            }

            public readonly static string description_revertAllUnstagedChanges = "";
            public static void revertAllUnstagedChanges()
            {
                // reset file to state without any changes
                if (liveRepository != null)
                {
                    string com = $"cd '{liveRepository.dirPath}'; ";
                    com += $"git checkout .";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                }
            }

            public readonly static string description_undoLastCommit = "";
            public static void undoLastCommit()
            {
                // 
            }
        }
    }

    /// <summary> Git Data Getters </summary>
    public static class Getters
    {

        public static List<Tuple<string, string>> getFileDiff(string fpath, bool isStaged)
        {
            Debug.WriteLine("getFileDiff : " + fpath);
            // assumes valid fpath
            if (liveRepository == null)
            {
                Debug.WriteLine("getFileDiff : liveRepository IS NULL");
                return new();
            }
            string stagedFlag = isStaged ? "--staged" : "";
            string com = $"cd '{liveRepository.dirPath}'; ";
            com += $"git diff {stagedFlag} '{fpath}'; ";
            ShellComRes result = Shell.exec(com);
            if (result.psObjects == null)
            {
                Debug.WriteLine("getFileDiff : PS OBJECTS IS NULL");
                return new();
            }
            Debug.WriteLine("getFileDiff : converting diff lines to string list");
            List<string> diffLines = result.psObjects.Select(s => s.ToString()).ToList();
            //List<string> diffOld = new();
            //List<string> diffNew = new();
            List<Tuple<string, string>> diff = new();

            foreach (string line in diffLines)
            {
                Debug.WriteLine("DIFF LINE : " + line);
            }

            Debug.WriteLine("getFileDiff : removing diff header");
            int i = 0;
            // stripping command output header
            foreach (string line in diffLines)
            {
                if (line[0].Equals('@'))
                {
                    break;
                }
                i++;
            }
            for (int j = 0; j < i; j++)
            {
                string line = diffLines[0];
                diffLines.RemoveAt(0);
                Debug.WriteLine("DIFF REMOVING HEADER LINE : " + line);
            }
            // building new and old
            foreach (string line in diffLines)
            {
                if (line[0].Equals('-'))
                {
                    diff.Add(new("\n", line));
                    /*
                    diffNew.Add("\n#");
                    diffOld.Add(line);
                    */
                }
                else if (line[0].Equals('+'))
                {
                    diff.Add(new(line, "\n"));
                    /*
                    diffNew.Add(line);
                    diffOld.Add("\n#");
                    */
                }
                else
                {
                    diff.Add(new(line, line));
                    /*
                    diffNew.Add(line);
                    diffOld.Add(line);
                    */
                }
            }
            return diff;
        }

        public static List<Tuple<string, string>> getStagedFiles()
        {
            // list<tuple<action,fpath>>
            if (liveRepository != null)
            {
                string com = $"cd '{liveRepository.dirPath}'; ";
                com += $"git diff --cached --name-status";
                ShellComRes result = Shell.exec(com);
                if (result.psObjects == null)
                {
                    return new();
                }
                // action(add,del,mod), fpath
                List<Tuple<string, string>> changes = new();
                foreach (PSObject pso in result.psObjects)
                {
                    string line = pso.ToString().Trim();
                    // line : eventNameChar     fpath
                    string action = line[0].ToString().ToUpper();
                    string fpath = line[1..].Trim();
                    Debug.WriteLine("GOT STAGED CHANGE");
                    Debug.WriteLine("LINE : " + line);
                    Debug.WriteLine("ACTION : " + action);
                    Debug.WriteLine("FPATH : " + fpath);
                    changes.Add(new Tuple<string, string>(action, fpath));
                }
                return changes;
            }
            return new();
        }

        public static List<Tuple<string, string>> getUnStagedFiles()
        {
            // list<tuple<action,fpath>>
            if (liveRepository != null)
            {
                string com = $"cd '{liveRepository.dirPath}'; ";
                com += $"git add -A -n";
                ShellComRes result = Shell.exec(com);
                if (result.psObjects == null)
                {
                    return new();
                }
                // action(add,del,mod), fpath
                List<Tuple<string, string>> changes = new();
                foreach (PSObject pso in result.psObjects)
                {
                    string line = pso.ToString().Trim();
                    // line : eventName 'fpath'
                    string[] splitLine = line.Split(" ");
                    // extracting
                    string action = line[0].ToString().ToUpper();
                    // extracting fname
                    string fpath = string.Join(" ", splitLine[1..]);
                    // removing enclosing parens
                    fpath = fpath.Substring(1, fpath.Length - 2);
                    Debug.WriteLine("UNSTAGED CHANGE");
                    Debug.WriteLine("ACTION : " + action);
                    Debug.WriteLine("FPATH : " + fpath);
                    changes.Add(new Tuple<string, string>(action, fpath));
                }
                return changes;
            }
            return new();
        }

        public readonly static string description_getRemoteRepositories = "";
        public static List<RepositoryRemote> getRemoteRepositories()
        {
            return remoteRepositories.Values.ToList();
        }


        public readonly static string description_getLocalRepositories = "";
        public static List<RepositoryLocal> getLocalRepositories()
        {
            return localRepositories.Values.ToList();
        }

        public readonly static string description_getAllRepositories = "";
        public static List<Tuple<RepositoryLocal?, RepositoryRemote?>> getAllRepositories()
        {
            //
            List<Tuple<RepositoryLocal?, RepositoryRemote?>> repoPairs = new List<Tuple<RepositoryLocal?, RepositoryRemote?>>();
            //
            HashSet<string> remoteURLs = remoteRepositories.Keys.ToHashSet();
            HashSet<string> localBackedURLS = remoteBackedLocalRepositories.Keys.ToHashSet();
            HashSet<string> allURLS = new HashSet<string>();
            allURLS.UnionWith(remoteURLs);
            allURLS.UnionWith(localBackedURLS);
            //
            HashSet<RepositoryLocal> curLocals = localRepositories.Values.ToHashSet();
            foreach (string remoteURL in allURLS)
            {

                // backed local + github
                if (remoteURLs.Contains(remoteURL) && localBackedURLS.Contains(remoteURL))
                {
                    RepositoryLocal? curLocal = null;
                    foreach (RepositoryLocal local in remoteBackedLocalRepositories[remoteURL])
                    {
                        RepositoryRemote remote = remoteRepositories[remoteURL];
                        curLocal = local;
                        repoPairs.Add(new Tuple<RepositoryLocal?, RepositoryRemote?>(local, remote));
                        Debug.WriteLine($"REPO : LOCAL BACKED WITH GITHUB : {local.title}");
                    }
                    if (curLocal != null)
                    {
                        curLocals.Remove(curLocal);

                    }
                }
                // backed local without github
                else if (localBackedURLS.Contains(remoteURL))
                {
                    RepositoryLocal? curLocal = null;
                    foreach (RepositoryLocal local in remoteBackedLocalRepositories[remoteURL])
                    {
                        curLocal = local;
                        repoPairs.Add(new Tuple<RepositoryLocal?, RepositoryRemote?>(local, null));
                        Debug.WriteLine($"REPO : LOCAL BACKED WITHOUT GITHUB : {local.title} URL={local.getRemoteURL()}");
                    }
                    if (curLocal != null)
                    {
                        curLocals.Remove(curLocal);
                    }
                }
                // github only
                else
                {
                    RepositoryRemote remote = remoteRepositories[remoteURL];
                    repoPairs.Add(new Tuple<RepositoryLocal?, RepositoryRemote?>(null, remote));
                    Debug.WriteLine($"REPO : GITHUB ONLY : {remote.title} : URL={remote.cloneURL}");
                }
            }
            // local only
            foreach (RepositoryLocal local in curLocals)
            {
                repoPairs.Add(new Tuple<RepositoryLocal?, RepositoryRemote?>(local, null));
                Debug.WriteLine($"REPO : LOCAL ONLY : {local.title}");
            }
            //
            return repoPairs;
        }


        public static Tuple<string?, string?> getLiveCommitShortHashAndBranch()
        {
            if (liveRepository != null)
            {
                string com = $"cd '{liveRepository.dirPath}'; ";
                com += $"git log -1 --pretty=format:%h";
                ShellComRes result = Shell.exec(com);
                if (result.psObjects == null)
                {
                    return new(null, null);
                }
                if (result.psObjects.Count == 0)
                {
                    return new(null, null);
                }
                string shortHash = result.psObjects[0].ToString().Trim();
                Debug.WriteLine($"CURRENT COMMIT SHORT HASH {shortHash}");

                com = $"cd '{liveRepository.dirPath}'; ";
                com += $"git rev-parse --abbrev-ref HEAD";
                result = Shell.exec(com);
                if (result.psObjects == null)
                {
                    return new(null, null);
                }
                string? branchName = result.psObjects[0].ToString().Trim();
                Debug.WriteLine($"CURRENT BRANCH NAME {branchName}");
                if (branchName == "HEAD")
                {
                    branchName = null;
                }

                return new(shortHash, branchName);
            }
            return new(null, null);
        }


        public static void setCommitsAheadAndBehind()
        {
            Debug.WriteLine($"setCommitsAheadAndBehind()");
            if (liveRepository != null)
            {
                if (liveBranch != null)
                {
                    string com = $"cd '{liveRepository.dirPath}'; ";
                    com += $"git rev-list --left-right --count {liveBranch.title}...origin/{liveBranch.title}";
                    Debug.WriteLine($"setCommitsAheadAndBehind : com= >{com}<");
                    ShellComRes result = Shell.exec(com);
                    if (result.psObjects == null)
                    {
                        commitsAhead = null;
                        commitsBehind = null;
                        Debug.WriteLine($"setCommitsAheadAndBehind : res is null");
                        return;
                    }
                    if (result.psObjects.Count == 0)
                    {
                        commitsAhead = null;
                        commitsBehind = null;
                        Debug.WriteLine($"setCommitsAheadAndBehind : res line count is 0");
                        return;
                    }
                    string line = result.psObjects[0].ToString().Trim();
                    line = Regex.Replace(line, @"\s+", " ");
                    string[] nums = line.Split(" ");
                    commitsBehind = int.Parse(nums[1]);
                    commitsAhead = int.Parse(nums[0]);
                    Debug.WriteLine($"SET COMMIT COUNTS : ahead={commitsAhead} behind={commitsBehind}");
                }
                else
                {
                    Debug.WriteLine($"setCommitsAheadAndBehind : live branch is null");
                    commitsAhead = null;
                    commitsBehind = null;
                    return;
                }

            }
            else
            {
                commitsAhead = null;
                commitsBehind = null;
            }
        }


        public static bool populateCommitGraphData(Commit cur, int colIndex)
        {
            if (cur.graphColIndex != -1)
            {
                // cur has already been visited
                return true;
            }
            cur.graphColIndex = colIndex;
            int childColIndex = colIndex;
            IEnumerable<Commit> reverseChildren = cur.children;
            foreach (Commit child in reverseChildren.Reverse())
            {
                bool alreadyVisited = populateCommitGraphData(child, childColIndex);
                if (alreadyVisited)
                {
                    childColIndex--;
                }
                else
                {
                    childColIndex++;
                }
                
                Tuple<int, int> outRowColPair = new(cur.graphRowIndex, cur.graphColIndex);
                child.graphOutRowColPairs.Add(outRowColPair);
                
                Tuple<int, int> inRowColPair = new(child.graphRowIndex, child.graphColIndex);
                cur.graphInRowColPairs.Add(inRowColPair);
            }
            // cur has been visited for the first time
            return false;
        }

        public static Tuple<List<Branch>, List<Commit>> getCommitsAndBranches()
        {
            Tuple<string?, string?> liveCommitShortHashAndBranchName = getLiveCommitShortHashAndBranch();
            string? liveCommitShortHash = liveCommitShortHashAndBranchName.Item1;
            string? liveBranchName = liveCommitShortHashAndBranchName.Item2;

            if (liveRepository != null)
            {
                string baseCom = $"cd '{liveRepository.dirPath}'; ";

                // Commit hash (H)
                // Abbreviated commit hash (h)
                // Tree hash (T)
                // Parent Hashes (P)
                // Committer name (cn)
                // Committer date (cd)
                // Subject (s)

                // all commits
                Dictionary<string, Commit> longHashToCommitDict = new Dictionary<string, Commit>();
                Dictionary<string, Commit> shortHashToCommitDict = new Dictionary<string, Commit>();
                List<Commit> commits = new List<Commit>();
                string delim = " | ";
                string com = baseCom + $"git log --all --oneline --pretty=format:\"%H{delim}%h{delim}%T{delim}%P\"";
                ShellComRes comResult = Shell.exec(com);
                if (comResult.psObjects == null)
                {
                    return new(new(), new());
                }

                // longCommitHash, shortCommitHash, longTreeHash, parentHashes
                foreach (PSObject pso in comResult.psObjects)
                {
                    string sline = pso.ToString().Trim();
                    string[] cols = sline.Split(delim);

                    Commit commit = new Commit();
                    commit.localRepository = liveRepository;
                    commit.longCommitHash = cols[0];
                    commit.shortCommitHash = cols[1];
                    commit.longTreeHash = cols[2];

                    commit.comRes = sline;

                    if (cols.Length > 3)
                    {
                        foreach (string parentHash in cols[3].Split(" "))
                        {
                            commit.parentHashes.Add(parentHash.Trim());
                        }
                    }
                    longHashToCommitDict[commit.longCommitHash] = commit;
                    shortHashToCommitDict[commit.shortCommitHash] = commit;
                    commits.Add(commit);

                    if (liveCommitShortHash != null)
                    {
                        if (commit.shortCommitHash == liveCommitShortHash)
                        {
                            liveCommit = commit;
                        }
                    }
                }

                // committer name
                com = baseCom + $"git log --all --oneline --pretty=format:\"%cn\"";
                comResult = Shell.exec(com);
                if (comResult.psObjects == null)
                {
                    return new(new(), new());
                }
                int i = 0;
                foreach (PSObject pso in comResult.psObjects)
                {
                    string committerName = pso.ToString().Trim();
                    Commit commit = commits[i];
                    commit.committerName = committerName;
                    i++;
                }

                // committer date
                com = baseCom + $"git log --all --oneline --pretty=format:\"%cd\"";
                comResult = Shell.exec(com);
                if (comResult.psObjects == null)
                {
                    return new(new(), new());
                }
                i = 0;
                foreach (PSObject pso in comResult.psObjects)
                {
                    string gitDateFormat = pso.ToString().Trim();
                    DateTime committerDate;
                    DateTime.TryParseExact(
                        gitDateFormat,
                        "ddd MMM d HH:mm:ss yyyy K",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None,
                        out committerDate
                    );
                    Commit commit = commits[i];
                    commit.committerDate = committerDate;
                    i++;
                }

                // subject
                com = baseCom + $"git log --all --oneline --pretty=format:\"%s\"";
                comResult = Shell.exec(com);
                if (comResult.psObjects == null)
                {
                    return new(new(), new());
                }
                i = 0;
                foreach (PSObject pso in comResult.psObjects)
                {
                    string subject = pso.ToString().Trim();
                    Commit commit = commits[i];
                    commit.subject = subject;
                    i++;
                }

                // setting internal refs to build commit tree
                foreach (KeyValuePair<string, Commit> kvp in longHashToCommitDict)
                {
                    string longHash = kvp.Key;
                    Commit commit = kvp.Value;
                    foreach (string parentHash in commit.parentHashes)
                    {
                        Commit parentCommit = longHashToCommitDict[parentHash];
                        commit.parents.Add(parentCommit);
                        parentCommit.children.Add(commit);
                    }
                }

                // populating graph row properties of commits
                int commitGraphRowIndex = commits.Count - 1;
                foreach (Commit c in commits)
                {
                    c.graphRowIndex = commitGraphRowIndex;
                    commitGraphRowIndex--;
                    //Debug.WriteLine("TEST COMMIT");
                }
                // populating graph col properties of commits
                if (commits.Count > 0)
                {
                    Commit initCommit = commits.Last();
                    populateCommitGraphData(initCommit, 0);
                    // printing graph
                    foreach (Commit c in commits)
                    {
                        string leftOffset = string.Concat(Enumerable.Repeat("  ", c.graphColIndex));
                        Debug.WriteLine(leftOffset + $"* (graphRowIndex={c.graphRowIndex} childCount={c.children.Count} parentHashes={c.parentHashes.Count})" + c.subject);
                        //Debug.WriteLine(leftOffset  + $"* (graphRowIndex={c.graphRowIndex} childCount={c.children.Count} parentHashes={c.parentHashes.Count} comRes={c.comRes})" + c.subject);
                    }
                }

                // getting all branches
                List<Branch> allBranches = new List<Branch>();
                // getting commits
                // list local branchs : *(live or not) | name | short hash | most recent commit msg
                com = baseCom + $"git branch -vva";
                comResult = Shell.exec(com);
                if (comResult.psObjects == null)
                {
                    return new(new(), new());
                }
                foreach (PSObject pso in comResult.psObjects)
                {
                    string line = pso.ToString().TrimEnd();
                    line = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ");
                    string[] items = line.Split(" ");
                    bool live = items[0].Equals("*");
                    string title = items[1];
                    string shortCommitHash = items[2];
                    // setting branhc-commit refs
                    if (shortHashToCommitDict.ContainsKey(shortCommitHash))
                    {
                        Commit commit = shortHashToCommitDict[shortCommitHash];
                        Branch branch = new Branch(title, commit);
                        commit.branches.Add(branch);
                        allBranches.Add(branch);

                        if (liveCommitShortHash != null && liveBranchName != null)
                        {
                            if (liveCommitShortHash == shortCommitHash && liveBranchName == branch.title)
                            {
                                liveBranch = branch;
                            }
                        }
                    }
                }

                setCommitsAheadAndBehind();

                // branches-commits tuples
                return new Tuple<List<Branch>, List<Commit>>(allBranches, commits);
            }

            return new(new(), new());
        }
    }
}
