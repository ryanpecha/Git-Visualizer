
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace GitVisualizer;

public static class GitAPI
{
    public static Commit? liveCommit { get; private set; }
    public static RepositoryLocal? liveRepository { get; private set; }
    private static PowerShell shell;

    static GitAPI()
    {
        // TODO load most repo from config file
        liveCommit = null;
        liveRepository = null;
        shell = PowerShell.Create();
    }

    private static void execShellCommand(Command command)
    {
        shell.Commands.AddCommand(command);
        Collection<PSObject> psObjects = shell.Invoke();
        foreach (PSObject psObject in psObjects)
        {
            Debug.WriteLine(psObject);
        }
    }

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
        }

        public static class LocalActions
        {
            public static void setLiveRepository(RepositoryLocal repositoryLocal)
            {
                if (!ReferenceEquals(repositoryLocal, liveRepository))
                {
                    // TODO check that .git folder and repo exist
                    Command com_cd = new Command("cd");
                    com_cd.Parameters.Add(repositoryLocal.dirPath);
                    execShellCommand(com_cd);
                    Command com_git_init = new Command("git");
                    com_git_init.Parameters.Add("init");
                    execShellCommand(com_git_init);
                }
            }

            public static void checkoutCommit(Commit commit)
            {
                if (!ReferenceEquals(commit, liveCommit))
                {
                    // TODO check that commit exists
                    //execShellCommand($"git checkout {commit.longHash};");
                    liveCommit = commit;
                }
            }

            public static void checkoutBranch(Branch branch)
            {
                if (!ReferenceEquals(branch.commit, liveCommit))
                {
                    // TODO check that branch exists and points to a valid commit
                    //execShellCommand($"git checkout {branch.title};");
                    liveCommit = branch.commit;
                }
            }

            public static void createBranch(string title)
            {

            }

            public static void deleteBranch(Branch branch)
            {

            }

            public static void scanRepositories(string localScanDirPath, bool recursive)
            {

            }

            public static void cloneRemote(RepositoryRemote repositoryRemote, string localCloneDirPath)
            {

            }

            public static void sync()
            {

            }

            public static void fetch()
            {

            }

            public static void pull()
            {

            }

        }

        // actions on the local filesystem within the currently checked-out commit
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

            public readonly static string push_description = "";
            public static void push()
            {

            }

            /*
            public static void undoPush()
            {

            }
            */
        }
    }

    public static class Views
    {
        public static class RemoteViews
        {

        }

        public static class LocalViews
        {

        }

        public static class LiveViews
        {

        }
    }

}
