namespace GitVisualizer;

public class Repository
{
    public string title { get; private set; }

    //public HashSet<string,Commit> commits;

    public Repository(string title)
    {
        this.title = formatTitle(title);
    }

    public static string formatTitle(string title)
    {
        return title.Replace(" ", "-");
    }

    public override string ToString()
    {
        return title;
    }
    
}
