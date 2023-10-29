namespace GitVisualizer;

public class RepositoryRemote : Repository
{
    //public string cloneUrlSSH { get; private set; }
    public string cloneUrlHTTPS { get; private set; }

    public RepositoryRemote(string title,/* string cloneUrlSSH,*/ string cloneUrlHTTPS) : base(title)
    {
        //this.cloneUrlSSH = cloneUrlSSH;
        this.cloneUrlHTTPS = cloneUrlHTTPS;
    }
}
