using System.Diagnostics;
using System.Text.Json;

public class GVSettings
{
    private static readonly string SETTINGS_FPATH = "gitVis.json";

    public string githubAppToken { get; set; }
    public List<LocalTracking> trackedLocalDirs { get; set; }
    public List<LocalTracking> trackedLocalRepos { get; set; }

    // try load file, else defaults
    public GVSettings()
    {
        if (!Path.Exists(SETTINGS_FPATH))
        {
            this.githubAppToken = "";
            this.trackedLocalDirs = new List<LocalTracking>();
            this.trackedLocalRepos = new List<LocalTracking>();
            return;
        }
        else
        {

        }
    }

    public static void debugPath()
    {
        Debug.WriteLine("ROOT SETTINGS PATH : " + Path.GetFullPath(SETTINGS_FPATH));
    }

    public static void saveSettings()
    {
        GVSettings settingsRef = new GVSettings();
        string settingsString = JsonSerializer.Serialize(settingsRef);
        File.WriteAllText(SETTINGS_FPATH, settingsString);
    }

    public class LocalTracking
    {
        public string path { get; set; }
        public bool recursive { get; set; }
        public LocalTracking(string path, bool recursive)
        {
            this.path = path;
            this.recursive = recursive;
        }
    }
}
