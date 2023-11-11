namespace GitVisualizer;

public class RepositoryRemote : Repository
{
    public RepositoryLocal? localRepository { get; private set; }

    public string cloneURL { get; private set; }

    public RepositoryRemote(string title, string cloneURL) : base(title)
    {
        this.cloneURL = cloneURL;
    }

    public void setLocalRepo(RepositoryLocal localRepository)
    {
        this.localRepository = localRepository;
    }
}
