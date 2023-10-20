
using System.Diagnostics;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GitVisualizer;

public static class GitAPI
{
    /// <summary> pointer to the live commit </summary>
    public static Branch? liveBranch { get; private set; }

    /// <summary> currently checked out commit </summary>
    public static Commit? liveCommit { get; private set; }

    /// <summary> currently tracked local repository </summary>
    public static RepositoryLocal? liveRepository { get; private set; }

    /// <summary> </summary>
    public static string? liveRepositoryDirPath { get; private set; }

    /// <summary> persistent shell instance for running commands </summary>
    private static PowerShell shell;


    //
    private static Dictionary<string, RepositoryRemote> remoteRepositories;
    //
    private static Dictionary<string, RepositoryLocal> localRepositories;
    //
    private static Dictionary<string, bool> trackedDirRecurDict;
    //
    private static void scanRepositories()
    {
        foreach (KeyValuePair<string, bool> entry in trackedDirRecurDict)
        {
            string dirPath = entry.Key;
            bool recursive = entry.Value;
            SearchOption searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            string[] gitFolderPaths = Directory.GetDirectories(dirPath, ".git/", searchOption);
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
                // skipping already loaded repositories
                if (localRepositories.Keys.Contains(repoDirPath))
                {
                    continue;
                }
                // 
                string repoName = repoDirInfo.Name;
                // TODO extract repo name from .git via git command
                RepositoryLocal newLocalRepo = new RepositoryLocal(repoName, repoDirPath);
                localRepositories[repoName] = newLocalRepo;
            }
        }
    }


    /// <summary> GitAPI initialization </summary>
    static GitAPI()
    {
        shell = PowerShell.Create();
        // TODO load tracked repos and previous program state from config file
        liveCommit = null;
        liveRepository = null;
        liveRepositoryDirPath = null;
        //
        remoteRepositories = new Dictionary<string, RepositoryRemote>();
        localRepositories = new Dictionary<string, RepositoryLocal>();
        //
        trackedDirRecurDict = new Dictionary<string, bool>();
        //
        scanRepositories();
    }



    /// <summary> structure used to represent the results of a shell command</summary>
    private struct ShellCommandResult
    {
        public bool success { get; private set; }
        public string? errmsg { get; private set; }
        public Collection<PSObject>? psObjects { get; private set; }
        public ShellCommandResult(bool success, string? errmsg, Collection<PSObject>? psObjects)
        {
            this.success = success;
            this.errmsg = errmsg;
            this.psObjects = psObjects;
        }
    }

    /// <summary> synchronously executes the given command returns the result struct </summary>
    private static ShellCommandResult execShellCommand(Command command)
    {
        // TODO async shell command queue
        try
        {
            shell.Commands.AddCommand(command);
            Collection<PSObject> psObjects = shell.Invoke();
            bool success = !shell.HadErrors;
            string? errmsg = null;
            if (!success)
            {
                ErrorRecord err = shell.Streams.Error[0];
                errmsg = err.ToString();
                shell.Streams.Error.Clear();
            }
            return new ShellCommandResult(success, errmsg: errmsg, psObjects: psObjects);
        }
        catch (Exception e)
        {
            string errmsg = e.ToString();
            return new ShellCommandResult(success: false, errmsg: errmsg, psObjects: null);
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
                    ShellCommandResult result = execShellCommand(com);
                    // TODO check for command success
                    Command com_git_init = new Command("git");
                    com_git_init.Parameters.Add("init");
                    result = execShellCommand(com_git_init);
                    // TODO check for command success
                    liveRepository = repositoryLocal;
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
                    ShellCommandResult result = execShellCommand(com);
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
                    ShellCommandResult result = execShellCommand(com);
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
                ShellCommandResult result = execShellCommand(com);
                // TODO check for command success
                Branch branch = new Branch(title, commit);
                // TODO add new branch to global branch
                liveCommit = branch.commit;
            }


            public readonly static string addLocalBranchToRemote_description = "";
            public static void addLocalBranchToRemote()
            {
                // git push -u origin <branch>
            }


            public readonly static string deleteBranchLocal_description = "";
            public static void deleteBranchLocal(Branch branch)
            {

            }


            public readonly static string deleteRemoteBranch_description = "";
            public static void deleteRemoteBranch(Branch branch)
            {

            }


            public readonly static string cloneRemoteRepository_description = "";
            public static void cloneRemoteRepository(RepositoryRemote repositoryRemote, string localCloneDirPath)
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

        public readonly static string keepTrackOfDirectory_description = "";
        public static void keepTrackOfDirectory(string dirPath, bool recursive)
        {
            trackedDirRecurDict[dirPath] = recursive;
            scanRepositories();
        }
    }

}
