namespace GitVisualizer;

public class Commit
{
    public string shortHash { get; private set; }
    public string longHash { get; private set; }
    public Repository repository { get; private set; }

    public Commit(string shortHash, string longHash, Repository repository)
    {
        this.shortHash = shortHash;
        this.longHash = longHash;
        this.repository = repository;
    }

}
