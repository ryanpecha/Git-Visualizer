namespace GitVisualizer;

public class RepositoryLocal
{
    public string dirPath { get; private set; }
    public RepositoryLocal(string dirPath)
    {
        this.dirPath = dirPath;
    }
}
