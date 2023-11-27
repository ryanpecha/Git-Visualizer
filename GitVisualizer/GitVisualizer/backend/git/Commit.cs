namespace GitVisualizer;

public class Commit
{
    public RepositoryLocal localRepository;
    public List<Branch> branches;

    public string longCommitHash;
    public string shortCommitHash;
    public string longTreeHash;
    public List<string> parentHashes;

    public string committerName;
    public DateTime committerDate;
    public string subject;

    public List<Commit> parents;
    public List<Commit> children;
}
