using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;


public static class Shell
{

    /// <summary> persistent shell instance for running commands </summary>
    private static PowerShell iShell;

    static Shell()
    {
        iShell = PowerShell.Create();
    }

    /// <summary> synchronously executes the given command returns the result struct </summary>
    public static ShellComRes exec(string command)
    {
        // TODO async shell command queue
        try
        {
            iShell.Commands.Clear();
            iShell.AddScript(command);
            Collection<PSObject> psObjects = iShell.Invoke();
            bool success = !iShell.HadErrors;
            string? errmsg = null;
            if (!success)
            {
                ErrorRecord err = iShell.Streams.Error[0];
                errmsg = err.ToString();
                iShell.Streams.Error.Clear();
            }
            return new ShellComRes(success, errmsg: errmsg, psObjects: psObjects);
        }
        catch (Exception e)
        {
            string errmsg = e.ToString();
            return new ShellComRes(success: false, errmsg: errmsg, psObjects: null);
        }
    }
}

/// <summary> class used to represent the results of a shell command</summary>
public class ShellComRes
{
    public bool success { get; private set; }
    public string? errmsg { get; private set; }
    public Collection<PSObject>? psObjects { get; private set; }
    public ShellComRes(bool success, string? errmsg, Collection<PSObject>? psObjects)
    {
        this.success = success;
        this.errmsg = errmsg;
        this.psObjects = psObjects;
    }
}
