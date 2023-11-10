namespace GitVisualizer;

public class RepositoryLocal : Repository
{
    public string dirPath { get; private set; }
    public RepositoryLocal(string title, string dirPath) : base(title)
    {
        this.dirPath = dirPath;
    }

    public override string ToString()
    {
        return dirPath;
    }
}
