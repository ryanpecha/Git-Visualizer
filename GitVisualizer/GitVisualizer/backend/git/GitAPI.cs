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

namespace GitVisualizer;

// TODO - load current checked out commit/branch on initial branch view
// TODO - keep track of remote branches
// TODO - load previously loaded repo on program startup
// TODO - load staged changes on initial branch view
// TODO - 

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

        //
        public static void scanForLocalRepos(Action? callback)
        {
            Debug.WriteLine("scanDirs()");
            foreach (LocalTrackedDir trackedDir in GVSettings.data.trackedLocalDirs)
            {
                Debug.WriteLine($"SCANNING recursive={trackedDir.recursive} path={trackedDir.path}");
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
                    // TODO extract repo name from .git via git command
                    string repoName = repoDirInfo.Name;
                    RepositoryLocal newLocalRepo = new RepositoryLocal(repoName, repoDirPath);

                    // skipping already loaded local repos
                    if (localRepositories.ContainsKey(newLocalRepo.dirPath))
                    {
                        continue;
                    }
                    Debug.WriteLine($"LOCATED LOCAL REPO title={repoName} path={repoDirPath}");
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
                    Debug.WriteLine($"LOCATED BACKING FOR LOCAL REPO title={repoName} path={repoDirPath} remote={remoteURL}");
                }
            }
            if (callback != null)
            {
                Debug.WriteLine("scanDirs() calling callback");
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
            else
            {
                Debug.WriteLine("WARNING : GitHub remote fetch returned null");
            }
            if (callback != null)
            {
                Debug.WriteLine("scanRemotesAsync() calling callback");
                callback();
            }
        }


        //
        public static async void scanForAllReposAsync(Action? callback)
        {
            Debug.WriteLine("scanAllAsync()");
            // loading local repositories
            scanForLocalRepos(null);
            // loading remote repositories
            await scanForRemoteReposAsync(null);
            if (callback != null)
            {
                Debug.WriteLine("scanAllAsync() calling callback");
                callback();
            }
        }
    }

    /// <summary> Git Actions </summary>
    public static class Actions
    {
        public static class RemoteActions
        {
            public readonly static string description_deleteRemoteRepository = "";
            public static void deleteRemoteRepository()
            {
                // TODO delete
            }


            public readonly static string description_createRemoteRepository = "";
            public static void createRemoteRepository()
            {

            }


            public readonly static string description_push = "";
            public static void push()
            {

            }


            public readonly static string description_addLocalBranchToRemote = "";
            public static void addLocalBranchToRemote(Branch branch)
            {
                // git push -u origin <branch>
            }


            public readonly static string description_deleteRemoteBranch = "";
            public static void deleteRemoteBranch(Branch branch)
            {

            }


            public readonly static string description_cloneRemoteRepository = "";
            public static void cloneRemoteRepository(RepositoryRemote repositoryRemote, Action? callback)
            {
                // TODO check that .git folder and repo exist
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                DialogResult fdResult = dialog.ShowDialog();
                if (fdResult == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    string cloneDirPath = Path.GetFullPath(dialog.SelectedPath);
                    string clonedRepoPath = cloneDirPath + "/" + repositoryRemote.title;
                    //
                    string com = $"cd {cloneDirPath}; ";
                    com += $"git clone {repositoryRemote.cloneURL}";
                    ShellComRes comResult = Shell.exec(com);
                    // TODO check for command success
                    LocalActions.trackDirectory(clonedRepoPath, true, callback);
                }
            }

        }



        /// <summary> actions on the local filesystem within the currently checked-out commit </summary>
        public static class LocalActions
        {

            public readonly static string description_getCloneURL = "";

            public readonly static string description_setLiveRepository = "";
            public static void setLiveRepository(RepositoryLocal repositoryLocal)
            {
                if (!ReferenceEquals(repositoryLocal, liveRepository))
                {
                    // TODO check that .git folder and repo exist
                    string com = $"cd {repositoryLocal.dirPath}; ";
                    com += $"git init {repositoryLocal.dirPath}";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                    liveRepository = repositoryLocal;
                    // TODO set commit to currently checked out repo commit
                    //liveCommit = ;
                }
            }


            public readonly static string description_checkoutCommit = "";
            public static void checkoutCommit(Commit commit)
            {
                if (!ReferenceEquals(commit, liveCommit))
                {
                    // TODO check that commit exists
                    string com = $"cd {commit.localRepository.dirPath}; ";
                    com += $"git checkout {commit.longCommitHash}";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                    liveCommit = commit;
                    liveBranch = null;
                }
            }


            public readonly static string description_checkoutBranch = "";
            public static void checkoutBranch(Branch branch)
            {
                if (!ReferenceEquals(branch.commit, liveCommit))
                {
                    // TODO check that branch exists and points to a valid commit
                    string com = $"cd {branch.commit.localRepository.dirPath}; ";
                    com += $"git checkout {branch.title}";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                    liveCommit = branch.commit;
                    liveBranch = branch;
                }
            }


            public readonly static string description_createLocalBranch = "";
            public static Branch createLocalBranch(string title, Commit commit)
            {
                // TODO check that branch does not exist
                string com = $"cd {commit.localRepository.dirPath}; ";
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
                    string com = $"cd {branch.commit.localRepository.dirPath}; ";
                    com += $"git branch -D {branch.title}";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                    com = $"cd {branch.commit.localRepository.dirPath}; ";
                    com += $"git push origin -d {branch.title}";
                    result = Shell.exec(com);
                }
            }

            public readonly static string description_merge = "";
            public static void merge()
            {

            }


            public readonly static string description_sync = "";
            public static void sync()
            {
                // fetch and pull
                if (liveCommit != null)
                {
                    string com = $"cd {liveCommit.localRepository.dirPath}; ";
                    com += $"git fetch --all";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                    com = $"cd {liveCommit.localRepository.dirPath}; ";
                    com += $"git pull --all";
                    result = Shell.exec(com);
                    // TODO check for command success
                }
            }


            public readonly static string description_commit = "";
            public static void commit()
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
                    string com = $"cd {repoDirPath}; ";
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
                    string com = $"cd {liveRepository.dirPath}; ";
                    com += $"git clean -fdx";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                }
            }

            public readonly static string description_stageChanges = "";
            public static void stageChange(string fpath)
            {
                // stage file changes to commit
            }

            public readonly static string description_unStageChanges = "";
            public static void unStageChange(string fpath)
            {
                // unstage file changes to commit

            }

            public readonly static string description_commitStagedChanges = "";
            public static void commitStagedChanges(string message)
            {

            }

            public readonly static string description_undoUnstagedChanges = "";
            public static void undoUnstagedChange(string fpath)
            {

            }

            public readonly static string description_undoLastCommit = "";
            public static void undoLastCommit()
            {

            }
        }
    }

    /// <summary> Git Data Getters </summary>
    public static class Getters
    {

        public static List<Tuple<string, string>> getStagedFiles()
        {
            if (liveRepository != null)
            {
                string com = $"cd {liveRepository.dirPath}; ";
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
                    string[] splitLine = line.Split(" ");
                    string action = splitLine[0][0].ToString().ToUpper();
                    string fpath = splitLine[1];
                    changes.Add(new Tuple<string, string>(action, fpath));
                }
                return changes;
            }
            return new();
        }

        public static List<Tuple<string, string>> getUnStagedFiles()
        {
            if (liveRepository != null)
            {
                string com = $"cd {liveRepository.dirPath}; ";
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
                    string[] splitLine = line.Split(" ");
                    string action = splitLine[0][0].ToString().ToUpper();
                    string fpath = splitLine[1];
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
                        Debug.WriteLine($"LOCAL BACKED WITH GITHUB : {local.title}");
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
                        Debug.WriteLine($"LOCAL BACKED WITHOUT GITHUB : {local.title} URL={local.getRemoteURL()}");
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
                    Debug.WriteLine($"GITHUB ONLY : {remote.title} : URL={remote.cloneURL}");
                }
            }
            // local only
            foreach (RepositoryLocal local in curLocals)
            {
                repoPairs.Add(new Tuple<RepositoryLocal?, RepositoryRemote?>(local, null));
                Debug.WriteLine($"LOCAL ONLY : {local.title}");
            }
            //
            return repoPairs;
        }


        public static Tuple<List<Branch>, List<Commit>> getCommitsAndBranches()
        {
            if (liveRepository != null)
            {
                string baseCom = $"cd {liveRepository.dirPath}; ";

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
                Commit? head = null;
                string delim = " | ";
                string com = baseCom + $"git log --oneline --pretty=format:\"%H{delim}%h{delim}%T{delim}%P\"";
                ShellComRes comResult = Shell.exec(com);
                if (comResult.psObjects == null)
                {
                    List<Branch> tb = new List<Branch>();
                    List<Commit> tc = new List<Commit>();
                    return new Tuple<List<Branch>, List<Commit>>(tb, tc);
                }

                // longCommitHash, shortCommitHash, longTreeHash, parentHashes
                foreach (PSObject pso in comResult.psObjects)
                {
                    Debug.WriteLine("COMMIT INFO >" + pso + "<");
                    string sline = pso.ToString().Trim();
                    string[] cols = sline.Split(delim);

                    Commit commit = new Commit();
                    commit.localRepository = liveRepository;
                    commit.longCommitHash = cols[0];
                    commit.shortCommitHash = cols[1];
                    commit.longTreeHash = cols[2];
                    if (cols.Length > 3)
                    {
                        foreach (string parentHash in cols[3].Split(" "))
                        {
                            commit.parentHashes.Add(parentHash);
                        }
                    }
                    else
                    {
                        head = commit;
                    }

                    longHashToCommitDict[commit.longCommitHash] = commit;
                    shortHashToCommitDict[commit.shortCommitHash] = commit;
                    commits.Add(commit);
                }

                // committer name
                com = baseCom + $"git log --oneline --pretty=format:\"%cn\"";
                comResult = Shell.exec(com);
                if (comResult.psObjects == null)
                {
                    List<Branch> tb = new List<Branch>();
                    List<Commit> tc = new List<Commit>();
                    return new Tuple<List<Branch>, List<Commit>>(tb, tc);
                }
                int i = 0;
                foreach (PSObject pso in comResult.psObjects)
                {
                    Debug.WriteLine("COMMITTER NAME >" + pso + "<");
                    string committerName = pso.ToString().Trim();
                    Commit commit = commits[i];
                    commit.committerName = committerName;
                    i++;
                }

                // committer date
                com = baseCom + $"git log --oneline --pretty=format:\"%cd\"";
                comResult = Shell.exec(com);
                if (comResult.psObjects == null)
                {
                    List<Branch> tb = new List<Branch>();
                    List<Commit> tc = new List<Commit>();
                    return new Tuple<List<Branch>, List<Commit>>(tb, tc);
                }
                i = 0;
                foreach (PSObject pso in comResult.psObjects)
                {
                    Debug.WriteLine("COMMITER DATE >" + pso + "<");
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
                com = baseCom + $"git log --oneline --pretty=format:\"%s\"";
                comResult = Shell.exec(com);
                if (comResult.psObjects == null)
                {
                    List<Branch> tb = new List<Branch>();
                    List<Commit> tc = new List<Commit>();
                    return new Tuple<List<Branch>, List<Commit>>(tb, tc);
                }
                i = 0;
                foreach (PSObject pso in comResult.psObjects)
                {
                    Debug.WriteLine("SUBJECT >" + pso + "<");
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

                // sorting commits by date
                List<Commit> sortedCommits = commits.OrderBy(o => o.committerDate).ToList();
                sortedCommits.Reverse();

                // getting all branches
                List<Branch> allBranches = new List<Branch>();
                // getting commits
                // list local branchs : *(live or not) | name | short hash | most recent commit msg
                com = baseCom + $"git branch -vv";
                comResult = Shell.exec(com);
                if (comResult.psObjects == null)
                {
                    List<Branch> tb = new List<Branch>();
                    List<Commit> tc = new List<Commit>();
                    return new Tuple<List<Branch>, List<Commit>>(tb, tc);
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
                    }
                }

                // branches-commits tuples
                return new Tuple<List<Branch>, List<Commit>>(allBranches, sortedCommits);
            }

            List<Branch> b = new List<Branch>();
            List<Commit> c = new List<Commit>();
            return new Tuple<List<Branch>, List<Commit>>(b, c);
        }
    }
}
