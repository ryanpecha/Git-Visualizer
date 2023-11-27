namespace GitVisualizer;

public class Branch
{
    public string title { get; private set; }
    public Commit commit { get; set; }

    public Branch(string title, Commit commit)
    {
        this.title = title;
        this.commit = commit;
    }

    public override string ToString()
    {
        return title;
    }
}
