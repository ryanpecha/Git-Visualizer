using System.Diagnostics;
using System.Management.Automation.Runspaces;
using System.Text.Json;
using System;
using System.Runtime.InteropServices;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

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


    //
    private static Dictionary<string, RepositoryRemote> remoteRepositories;
    //
    private static Dictionary<string, RepositoryLocal> localRepositories;



    /// <summary> GitAPI initialization </summary>
    static GitAPI()
    {
        Debug.WriteLine("INITIALIZING GIT API");

        // ref to program GitHub api
        github = Program.Github;

        //
        remoteRepositories = new Dictionary<string, RepositoryRemote>();
        localRepositories = new Dictionary<string, RepositoryLocal>();
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
                    // skipping already loaded repositories
                    if (localRepositories.Keys.Contains(newLocalRepo.title))
                    {
                        continue;
                    }
                    // 
                    Debug.WriteLine($"LOCATED REPO title={repoName} path={repoDirPath}");
                    localRepositories[newLocalRepo.title] = newLocalRepo;
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
            List<RepositoryRemote>? remotes = await github.ScanReposAsync();
            if (remotes != null)
            {
                foreach (RepositoryRemote remoteRepo in remotes)
                {
                    remoteRepositories[remoteRepo.title] = remoteRepo;
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
                    string com = $"cd {cloneDirPath}";
                    ShellComRes comResult = Shell.exec(com);
                    // TODO check for command success
                    com = $"git clone {repositoryRemote.cloneUrlHTTPS}";
                    comResult = Shell.exec(com);
                    // TODO check for command success
                    LocalActions.trackDirectory(clonedRepoPath, false, callback);
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
                    string com = $"cd {repositoryLocal.dirPath}";
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                    com = $"git init {repositoryLocal.dirPath}";
                    result = Shell.exec(com);
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
                    string com = $"git checkout {commit.longHash}";
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
                    string com = $"git checkout {branch.title}";
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
                string com = $"git checkout -b {title} {commit.longHash}";
                ShellComRes result = Shell.exec(com);
                // TODO check for command success
                Branch branch = new Branch(title, commit);
                // TODO add new branch to global branch
                liveCommit = branch.commit;
            }


            public readonly static string description_deleteBranchLocal = "";
            public static void deleteBranchLocal(Branch branch)
            {

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
            public static void createLocalRepository(string repoName, Action? callback)
            {
                // TODO check that .git folder and repo exist
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                DialogResult fdResult = dialog.ShowDialog();
                if (fdResult == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    string repoParentDirPath = Path.GetFullPath(dialog.SelectedPath);
                    string repoDirPath = repoParentDirPath + "/" + repoName;
                    //
                    string com = $"cd {repoParentDirPath}";
                    ShellComRes comResult = Shell.exec(com);
                    // TODO check for command success
                    com = $"git init --initial-branch=main {repoName}";
                    comResult = Shell.exec(com);
                    // TODO check for command success
                    trackDirectory(repoDirPath, false, callback);
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
        public static Dictionary<string, RepositoryRemote> getRemoteRepositories()
        {
            return remoteRepositories;
        }


        public readonly static string description_getLocalRepositories = "";
        public static Dictionary<string, RepositoryLocal> getLocalRepositories()
        {
            return localRepositories;
        }

        public readonly static string description_getAllRepositories = "";
        public static List<Tuple<RepositoryLocal?, RepositoryRemote?>> getAllRepositories()
        {
            Debug.WriteLine("GETTING ALL REPOS");
            List<Tuple<RepositoryLocal?, RepositoryRemote?>> repos = new List<Tuple<RepositoryLocal?, RepositoryRemote?>>();
            HashSet<string> repoNames = [.. localRepositories.Keys, .. remoteRepositories.Keys];
            foreach (string repoName in repoNames)
            {
                string gitFormattedRepoName = Repository.formatTitle(repoName);
                Debug.WriteLine("FOUND REPO : " + gitFormattedRepoName);
                RepositoryLocal? localRepo = null;
                if (localRepositories.ContainsKey(gitFormattedRepoName))
                {
                    localRepo = localRepositories[gitFormattedRepoName];
                }
                RepositoryRemote? remoteRepo = null;
                if (remoteRepositories.ContainsKey(gitFormattedRepoName))
                {
                    remoteRepo = remoteRepositories[gitFormattedRepoName];
                }
                Tuple<RepositoryLocal?, RepositoryRemote?> repo = new Tuple<RepositoryLocal?, RepositoryRemote?>(localRepo, remoteRepo);
                repos.Add(repo);
            }
            return repos;
        }
    }
}
