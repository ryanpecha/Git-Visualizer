namespace GitVisualizer;

public class Commit
{
    public RepositoryLocal localRepository;

    public string longCommitHash;
    public string shortCommitHash;
    public string longTreeHash;
    public string? parentHash;
    public string committerName;
    public string committerDate;
    public string subject;

    public List<Commit> parents;
    public List<Commit> children;
}
