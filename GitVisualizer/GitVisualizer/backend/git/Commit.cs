namespace GitVisualizer;

public class Commit
{
    public string shortHash { get; private set; }
    public string longHash { get; private set; }
    public RepositoryLocal localRepository { get; private set; }

    public Commit(string shortHash, string longHash, RepositoryLocal localRepository)
    {
        this.shortHash = shortHash;
        this.longHash = longHash;
        this.localRepository = localRepository;
    }

}
