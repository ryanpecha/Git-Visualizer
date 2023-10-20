namespace GitVisualizer;

public class Repository
{
    public string title { get; private set; }
    //public HashSet<string,Commit> commits;

    public Repository(string title)
    {
        this.title = title;
    }
}
