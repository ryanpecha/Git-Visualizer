namespace GitVisualizer;

public class Diff
{

    public Commit commitA { get; private set; }
    public Commit commitB { get; private set; }

    public Diff(Commit commitA, Commit commitB)
    {
        this.commitA = commitA;
        this.commitB = commitB;
        evaluateDiff();
    }

    public void recalcDiff(Commit commitA, Commit commitB)
    {
        this.commitA = commitA;
        this.commitB = commitB;
        evaluateDiff();
    }

    private void evaluateDiff()
    {

    }
}
