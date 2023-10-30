using System.Diagnostics;
using System.Text.Json;

public class GVSettings
{
    private static readonly string SETTINGS_FPATH = "gitVis.json";

    public string githubAppToken { get; set; }
    public List<LocalTrackedDir> trackedLocalDirs { get; set; }

    // try load file, else defaults
    public GVSettings()
    {
        githubAppToken = "";
        trackedLocalDirs = new List<LocalTrackedDir>();
        if (!Path.Exists(SETTINGS_FPATH))
        {
            saveSettings();
        }
        else
        {
            loadSettings();
        }
    }

    public static void debugPrintPath()
    {
        Debug.WriteLine("ROOT SETTINGS PATH : " + Path.GetFullPath(SETTINGS_FPATH));
    }

    public void loadSettings()
    {
        //
        string settingsStr = File.ReadAllText(SETTINGS_FPATH);
        GVSettings? settingsJson = JsonSerializer.Deserialize<GVSettings>(settingsStr);
        if (settingsJson == null)
        {
            throw new Exception("Settings file is invalid json");
        }
        else
        {
            githubAppToken = settingsJson.githubAppToken;
            trackedLocalDirs = settingsJson.trackedLocalDirs;
        }
    }

    public void saveSettings()
    {
        string settingsString = JsonSerializer.Serialize(this);
        File.WriteAllText(SETTINGS_FPATH, settingsString);
    }
}

public class LocalTrackedDir
{
    public string path { get; set; }
    public bool recursive { get; set; }
    public LocalTrackedDir(string path, bool recursive)
    {
        this.path = path;
        this.recursive = recursive;
    }
}
