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

                //localRepositories.Clear();
                //cloneableLocalRepositories.Clear();

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

    /*
        All repository actions

        Remote
        * Clone
        * Delete
        * Open on GitHub

        Local 
        * Create New
        ---
        * View
        * Delete
        * Add to GitHub (requires no existing remote)
        * Open in File Explorer
    */

    /*
        Current local repository actions

        * 
    */

    /// <summary> Git Actions </summary>
    public static class Actions
    {
        public static class RemoteActions
        {
            public readonly static string description_deleteRemoteRepository = "";
            public static void deleteRemoteRepository()
            {

            }


            public readonly static string description_createRemoteRepository = "";
            public static void createRemoteRepository()
            {

            }


            public readonly static string description_pushCommitToRemoteRepository = "";
            public static void pushCommitToRemoteRepository()
            {

            }


            public readonly static string description_addLocalBranchToRemote = "";
            public static void addLocalBranchToRemote()
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
            public static void createLocalBranch(string title, Commit commit)
            {
                // TODO check that branch does not exist
                string com = $"cd {commit.localRepository.dirPath}; ";
                com += $"git checkout -b {title} {commit.longCommitHash}";
                ShellComRes result = Shell.exec(com);
                // TODO check for command success
                Branch branch = new Branch(title, commit);
                // TODO add new branch to global branch
                liveCommit = branch.commit;
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
                // pull and push
            }


            public readonly static string description_fetch = "";
            public static void fetch()
            {
                // gets info about remote repositories
                if (liveCommit != null)
                {
                    string com = $"cd {liveCommit.localRepository.dirPath}; ";
                    com += $"git fetch -all";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                }
            }


            public readonly static string description_pull = "";
            public static void pull()
            {
                // fetch followed by a merge
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



            /// <summary> actions on the local filesystem within the currently checked-out commit </summary>
            public static class LiveActions
            {
                public readonly static string description_clean = "";
                public static void clean()
                {

                }

                public readonly static string description_add = "";
                public static void add(List<string> fpaths)
                {

                }

                public readonly static string description_undoAdd = "";
                public static void undoAdd(List<string> fpaths)
                {

                }

                public readonly static string description_commit = "";
                public static void commit()
                {

                }

                public readonly static string description_undoCommit = "";
                public static void undoCommit()
                {

                }
            }
        }
    }

    /// <summary> Git Data Getters </summary>
    public static class Getters
    {

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
            Debug.WriteLine("GETTING ALL REPOS");
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
            //
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

        public static List<Commit> getCommits()
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

                // git spung
                Dictionary<string, Commit> treeHashToCommitDict = new Dictionary<string, Commit>();

                string delim = " | ";

                string com = baseCom + $"git log --oneline --pretty=format:\"%H{delim}%h{delim}%T{delim}%P\"";
                ShellComRes comResult = Shell.exec(com);
                foreach (PSObject pso in comResult.psObjects)
                {
                    Debug.WriteLine("INFO1 >" + pso + "<");
                    string sline = pso.ToString().Trim();
                    if (sline.Equals(""))
                    {
                        continue;
                    }
                    string[] cols = sline.Split(delim);

                    Commit commit = new Commit();
                    commit.localRepository = liveRepository;

                    commit.longCommitHash = cols[0];
                    commit.shortCommitHash = cols[1];
                    commit.longTreeHash = cols[2];
                    commit.parentHash = (cols.Length > 3) ? cols[3] : null;

                    treeHashToCommitDict[commit.longCommitHash] = commit;
                }

                // %cn %cd %s

                /*
                com = baseCom + $"git log --oneline --pretty=format:\"\"";
                comResult = Shell.exec(com);
                foreach (PSObject pso in comResult.psObjects)
                {
                    Debug.WriteLine("INFO1 >" + pso + "<");
                    string sline = pso.ToString().Trim();
                    if (sline.Equals(""))
                    {
                        continue;
                    }
                    string[] cols = sline.Split(delim);

                    Commit commit = treeHashToCommitDict[commit.longCommitHash];

                    commit.longCommitHash = cols[0];
                    commit.shortCommitHash = cols[1];
                    commit.longTreeHash = cols[2];
                    commit.parentHash = cols[3];

                     = commit;
                }
                */

                foreach (KeyValuePair<string, Commit> kvp in treeHashToCommitDict)
                {
                    string longHash = kvp.Key;
                    Commit commit = kvp.Value;
                }
            }
            return new List<Commit>();
        }
    }
}
