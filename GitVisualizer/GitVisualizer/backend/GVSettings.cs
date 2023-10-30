using System.Text.Json;

public class GVSettings
{
    public string githubAppToken { get; set; }
    public List<Tracking> trackedLocalDirs { get; set; }
    public List<Tracking> trackedLocalRepos { get; set; }
    public GVSettings(string githubAppToken, List<Tracking> trackedLocalDirs, List<Tracking> trackedLocalRepos){
        this.githubAppToken = githubAppToken;
        this.trackedLocalDirs = trackedLocalDirs;
        this.trackedLocalRepos = trackedLocalRepos;
    }

    public static string getDefaultJsonStr() {
        GVSettings defaults = new GVSettings("", new List<Tracking>(), new List<Tracking>());
        return JsonSerializer.Serialize(defaults);
    }
}

public class Tracking
{
    public string path { get; set; }
    public bool recursive { get; set; }
    public Tracking(string path, bool recursive) {
        this.path = path;
        this.recursive = recursive;
    }
}
