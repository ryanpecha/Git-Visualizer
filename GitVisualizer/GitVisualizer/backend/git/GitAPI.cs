
using System.Diagnostics;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;

namespace GitVisualizer;

public static class GitAPI
{
    /// <summary> pointer to the live commit </summary>
    public static Branch? liveBranch { get; private set; }

    /// <summary> currently checked out commit </summary>
    public static Commit? liveCommit { get; private set; }

    /// <summary> currently tracked local repository </summary>
    public static RepositoryLocal? liveRepository { get; private set; }

    /// <summary> persistent shell instance for running commands </summary>
    private static PowerShell shell;


    /// <summary> GitAPI initialization </summary>
    static GitAPI()
    {
        // TODO load most repo from config file
        liveCommit = null;
        liveRepository = null;
        shell = PowerShell.Create();
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
            public static void deleteRemote()
            {

            }

            public static void createRemote()
            {

            }

            public readonly static string push_description = "";
            /// <summary>
            /// 
            /// </summary>
            public static void push()
            {

            }
        }



        /// <summary> actions on the local filesystem within the currently checked-out commit </summary>
        public static class LocalActions
        {

            /// <summary>
            /// 
            /// </summary>
            /// <param name="repositoryLocal"></param>
            public static void setLiveRepository(RepositoryLocal repositoryLocal)
            {
                if (!ReferenceEquals(repositoryLocal, liveRepository))
                {
                    // TODO check that .git folder and repo exist
                    Command com = new Command("cd");
                    com.Parameters.Add(repositoryLocal.dirPath);
                    ShellCommandResult result = execShellCommand(com);
                    // TODO check for command success
                    //Command com_git_init = new Command("git");
                    //com_git_init.Parameters.Add("init");
                    //execShellCommand(com_git_init);
                    // TODO check for command success
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="commit"></param>
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

            /// <summary>
            /// 
            /// </summary>
            /// <param name="branch"></param>
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

            /// <summary>
            /// Creates a new branch from the given commit and checks into the new branch
            /// </summary>
            /// <param name="title"></param>
            /// <param name="commit"></param>
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

            /// <summary>
            /// Creates a new branch from the live commit and checks into the new branch
            /// </summary>
            /// <param name="title"></param>
            public static void createLocalBranch(string title)
            {
                // TODO check that liveCommit is not null
                createLocalBranch(title, liveCommit);
            }

            public static void makeLocalBranchRemote()
            {
                // git push -u origin <branch>
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="branch"></param>
            public static void deleteBranchLocal(Branch branch)
            {

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="branch"></param>
            public static void deleteBranchRemote(Branch branch)
            {

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="localScanDirPath"></param>
            /// <param name="recursive"></param>
            public static void scanRepositories(string localScanDirPath, bool recursive)
            {
                /*
                Command com = new Command("echo");
                com.Parameters.Add("TESTING");
                execShellCommand(com);
                */
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="repositoryRemote"></param>
            /// <param name="localCloneDirPath"></param>
            public static void cloneRemote(RepositoryRemote repositoryRemote, string localCloneDirPath)
            {

            }

            /// <summary>
            /// 
            /// </summary>
            public static void sync()
            {

            }

            /// <summary>
            /// 
            /// </summary>
            public static void fetch()
            {

            }

            /// <summary>
            /// 
            /// </summary>
            public static void pull()
            {

            }

        }



        /// <summary> actions on the local filesystem within the currently checked-out commit </summary>
        public static class LiveActions
        {
            public readonly static string clean_description = "";
            /// <summary>
            /// 
            /// </summary>
            public static void clean()
            {

            }

            public readonly static string add_description = "";
            /// <summary>
            /// 
            /// </summary>
            /// <param name="fpaths"></param>
            public static void add(List<string> fpaths)
            {

            }

            public readonly static string undoAdd_description = "";
            /// <summary>
            /// 
            /// </summary>
            /// <param name="fpaths"></param>
            public static void undoAdd(List<string> fpaths)
            {

            }

            public readonly static string commit_description = "";
            /// <summary>
            /// 
            /// </summary>
            public static void commit()
            {

            }

            public readonly static string undoCommit_description = "";
            /// <summary>
            /// 
            /// </summary>
            public static void undoCommit()
            {

            }
        }
    }



    /// <summary> Git Data Getters </summary>
    public static class Getters
    {


        public static class RemoteGetters
        {
            public static List<RepositoryRemote> getRemoteRepositories()
            {

            }
        }



        public static class LocalGetters
        {
            public static List<RepositoryLocal> getLocalRepositories()
            {

            }
        }



        public static class LiveGetters
        {

        }
    }

}
