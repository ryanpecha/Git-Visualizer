namespace GitVisualizer;

public class Commit
{
    public RepositoryLocal localRepository {get; set;}
    public List<Branch> branches {get; set;} = new();

    public string longCommitHash {get; set;}
    public string shortCommitHash {get; set;}
    public string longTreeHash {get; set;}
    public List<string> parentHashes {get; set;} = new();

    public string committerName {get; set;}
    public DateTime committerDate {get; set;}
    public string subject {get; set;}

    public List<Commit> parents {get; set;} = new();
    public List<Commit> children {get; set;} = new();
}
