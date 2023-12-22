namespace GitVisualizer;

public class Commit
{

    public int graphRowIndex; // row 0 at bottom; 
    public int graphColIndex = -1; // col 0 is leftmost;
    
    // pointers to parent coords below <row,col>
    public List<Tuple<int,int>> graphOutRowColPairs = new();

    // pointers to child coords above <row,col>
    public List<Tuple<int,int>> graphInRowColPairs = new();

    public RepositoryLocal localRepository {get; set;}
    public List<Branch> branches {get; set;} = new();

    public string longCommitHash {get; set;}
    public string shortCommitHash {get; set;}
    public string longTreeHash {get; set;}
    public List<string> parentHashes {get; set;} = new();

    public string comRes {get; set;}

    public string committerName {get; set;}
    public DateTime committerDate {get; set;}
    public string subject {get; set;}

    public List<Commit> parents {get; set;} = new();
    public List<Commit> children {get; set;} = new();
}
