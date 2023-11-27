using System.Diagnostics;

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

    public string? getRemoteURL()
    {
        string? res = null;
        // TODO check that .git folder and repo exist
        string com = $"cd '{dirPath}'; ";
        com += $"git config --get remote.origin.url";
        ShellComRes result = Shell.exec(com);
        // TODO check for command success
        if (result.success)
        {
            if (result.psObjects != null)
            {
                if (result.psObjects.Count() > 0)
                {
                    if (result.psObjects[0] != null)
                    {
                        res = result.psObjects[0].ToString();
                        if (res.StartsWith("https://github.com/")){
                            // https 
                            if (! res.EndsWith(".git")){
                                res += ".git";
                            }
                            Debug.WriteLine($"getRemoteURL got res https : {res} | {dirPath}");
                            // stripping "https://"
                            res = res.Substring(8);
                        }
                        else if (res.StartsWith("git@github.com:")) {
                            // ssh
                            if (! res.EndsWith(".git")){
                                res += ".git";
                            }
                            Debug.WriteLine($"getRemoteURL got res ssh : {res} | {dirPath}");
                            // stripping "https://"
                            res = "github.com/" + res.Substring(15);
                        }
                        else {
                            // invalid
                            Debug.WriteLine($"getRemoteURL res is not https for : {res} | {dirPath}");
                        }
                    }
                    else {
                        Debug.WriteLine($"getRemoteURL cmd output line 0 null {dirPath}");
                    }
                }
                else {
                    Debug.WriteLine($"getRemoteURL cmd output count is 0 {dirPath}");
                }
            }
            else {
                Debug.WriteLine($"getRemoteURL cmd output is null {dirPath}");
            }
        }
        else {
            Debug.WriteLine($"getRemoteURL failed for {dirPath}");
        }
        Debug.WriteLine($"getRemoteURL returning {res} for {dirPath}");
        return res;
    }
}
