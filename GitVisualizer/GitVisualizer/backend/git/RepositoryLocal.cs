namespace GitVisualizer;

public class RepositoryLocal : Repository
{
    //public RepositoryRemote? remoteRepository { get; private set; }
    //public string? remoteURL { get; private set; }

    public string dirPath { get; private set; }
    public RepositoryLocal(string title, string dirPath) : base(title)
    {
        this.dirPath = dirPath;
        //remoteURL = getRemoteURL();
    }

    public override string ToString()
    {
        return dirPath;
    }

    /*
    public void setRemoteRepository(RepositoryRemote remoteRepository){
        this.remoteRepository = remoteRepository;
    }
    */

    public string? getRemoteURL()
    {
        string? res = null;
        // TODO check that .git folder and repo exist
        string com = $"cd {dirPath}; ";
        com += $"git config --get remote.origin.url";
        ShellComRes result = Shell.exec(com);
        // TODO check for command success
        if (result.success)
        {
            if (result.psObjects != null)
            {
                if (result.psObjects.Count() > 0)
                {

                    if (result.psObjects[0] != null)
                    {
                        res = result.psObjects[0].ToString();
                        if (res.StartsWith("https://")){
                            res = res.Substring(8);
                        }
                    }
                }
            }
        }
        return res;
    }
}
