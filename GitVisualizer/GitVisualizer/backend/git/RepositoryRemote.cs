namespace GitVisualizer;

public class RepositoryRemote : Repository
{
    //public RepositoryLocal? localRepository { get; private set; }

    public string cloneURL { get; private set; }
    public string webURL { get; private set; }

    public RepositoryRemote(string title, string cloneURL, string webURL) : base(title)
    {
        this.cloneURL = cloneURL;
        this.webURL = webURL;
    }

    /*
    public void setLocalRepo(RepositoryLocal localRepository)
    {
        this.localRepository = localRepository;
    }
    */
}
