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

        // TODO load previous program state from config file
        liveCommit = null;
        liveRepository = null;

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
            if (callback != null) {
                Debug.WriteLine("scanDirs() calling callback");
                callback();
            }
        }


        //
        public static async Task scanForRemoteReposAsync(Action? callback)
        {
            Debug.WriteLine("scanRemotesAsync()");
            List<RepositoryRemote>? remotes = await github.ScanReposAsync();
            if (remotes != null) {
                foreach (RepositoryRemote remoteRepo in remotes)
                {
                    remoteRepositories[remoteRepo.title] = remoteRepo;
                }
            }
            else {
                Debug.WriteLine("WARNING : GitHub remote fetch returned null");
            }
            if (callback != null) {
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
            if (callback != null) {
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
            public readonly static string deleteRemoteRepository_description = "";
            public static void deleteRemoteRepository()
            {

            }

            public readonly static string createRemoteRepository_description = "";
            public static void createRemoteRepository()
            {

            }

            public readonly static string pushCommitToRemoteRepository_description = "";
            public static void pushCommitToRemoteRepository()
            {

            }


            public readonly static string addLocalBranchToRemote_description = "";
            public static void addLocalBranchToRemote()
            {
                // git push -u origin <branch>
            }


            public readonly static string deleteRemoteBranch_description = "";
            public static void deleteRemoteBranch(Branch branch)
            {

            }


            public readonly static string cloneRemoteRepository_description = "";
            public static void cloneRemoteRepository(RepositoryRemote repositoryRemote)
            {
                // TODO check that .git folder and repo exist
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                DialogResult fdResult = dialog.ShowDialog();
                if (fdResult == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath)) {
                    string fullPath = Path.GetFullPath(dialog.SelectedPath);
                    //
                    Command com = new Command("cd");
                    com.Parameters.Add(fullPath);
                    ShellComRes comResult = Shell.exec(com);
                    // TODO check for command success

                    //
                    com = new Command("git");
                    com.Parameters.Add("clone");
                    com.Parameters.Add(repositoryRemote.cloneUrlHTTPS);
                    comResult = Shell.exec(com);
                    // TODO check for command success
                    
                    //com = new Command("git");
                    //com.Parameters.Add("init");
                    //comResult = Shell.exec(com);
                    // TODO check for command success

                    // TODO set commit to currently checked out repo commit
                    //liveCommit = ;
                }
            }

        }



        /// <summary> actions on the local filesystem within the currently checked-out commit </summary>
        public static class LocalActions
        {

            public readonly static string setLiveRepository_description = "";
            public static void setLiveRepository(RepositoryLocal repositoryLocal)
            {
                if (!ReferenceEquals(repositoryLocal, liveRepository))
                {
                    // TODO check that .git folder and repo exist
                    Command com = new Command("cd");
                    com.Parameters.Add(repositoryLocal.dirPath);
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                    com = new Command("git");
                    com.Parameters.Add("init");
                    result = Shell.exec(com);
                    // TODO check for command success
                    liveRepository = repositoryLocal;
                    // TODO set commit to currently checked out repo commit
                    //liveCommit = ;
                }
            }


            public readonly static string checkoutCommit_description = "";
            public static void checkoutCommit(Commit commit)
            {
                if (!ReferenceEquals(commit, liveCommit))
                {
                    // TODO check that commit exists
                    Command com = new Command("git");
                    com.Parameters.Add("checkout");
                    com.Parameters.Add(commit.longHash);
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                    liveCommit = commit;
                    liveBranch = null;
                }
            }


            public readonly static string checkoutBranch_description = "";
            public static void checkoutBranch(Branch branch)
            {
                if (!ReferenceEquals(branch.commit, liveCommit))
                {
                    // TODO check that branch exists and points to a valid commit
                    Command com = new Command("git");
                    com.Parameters.Add("checkout");
                    com.Parameters.Add(branch.title);
                    ShellComRes result = Shell.exec(com);
                    // TODO check for command success
                    liveCommit = branch.commit;
                    liveBranch = branch;
                }
            }


            public readonly static string createLocalBranch_description = "";
            public static void createLocalBranch(string title, Commit commit)
            {
                // TODO check that branch does not exist
                Command com = new Command("git");
                com.Parameters.Add("checkout");
                com.Parameters.Add("-b");
                com.Parameters.Add(title);
                com.Parameters.Add(commit.longHash);
                ShellComRes result = Shell.exec(com);
                // TODO check for command success
                Branch branch = new Branch(title, commit);
                // TODO add new branch to global branch
                liveCommit = branch.commit;
            }



            public readonly static string deleteBranchLocal_description = "";
            public static void deleteBranchLocal(Branch branch)
            {

            }



            public readonly static string merge_description = "";
            public static void merge()
            {

            }


            public readonly static string sync_description = "";
            public static void sync()
            {
                // pull and push
            }


            public readonly static string fetch_description = "";
            public static void fetch()
            {
                // gets info about remote repositories
            }


            public readonly static string pull_description = "";
            public static void pull()
            {
                // fetch followed by a merge
            }


            public readonly static string trackDirectory_description = "";
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

            public static void userSelectTrackDirectory(bool recursive, Action? callback) {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath)) {
                    string fullPath = Path.GetFullPath(dialog.SelectedPath);
                    trackDirectory(fullPath,recursive, callback);
                }
            }
        }



        /// <summary> actions on the local filesystem within the currently checked-out commit </summary>
        public static class LiveActions
        {
            public readonly static string clean_description = "";
            public static void clean()
            {
                
            }

            public readonly static string add_description = "";
            public static void add(List<string> fpaths)
            {

            }

            public readonly static string undoAdd_description = "";
            public static void undoAdd(List<string> fpaths)
            {
                
            }

            public readonly static string commit_description = "";
            public static void commit()
            {

            }

            public readonly static string undoCommit_description = "";
            public static void undoCommit()
            {
                
            }
        }
    }



    /// <summary> Git Data Getters </summary>
    public static class Getters
    {

        public readonly static string getRemoteRepositories_description = "";
        public static Dictionary<string, RepositoryRemote> getRemoteRepositories()
        {
            return remoteRepositories;
        }


        public readonly static string getLocalRepositories_description = "";
        public static Dictionary<string, RepositoryLocal> getLocalRepositories()
        {
            return localRepositories;
        }


        public static List<Tuple<string, RepositoryLocal?, RepositoryRemote?>> getAllRepositories()
        {
            Debug.WriteLine("GETTING ALL REPOS");
            List<Tuple<string, RepositoryLocal?, RepositoryRemote?>> repos = new List<Tuple<string, RepositoryLocal?, RepositoryRemote?>>();
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
                Tuple<string, RepositoryLocal?, RepositoryRemote?> repo = new Tuple<string, RepositoryLocal?, RepositoryRemote?>(repoName, localRepo, remoteRepo);
                repos.Add(repo);
            }
            return repos;
        }
    }

}
