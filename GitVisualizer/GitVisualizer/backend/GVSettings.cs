using System.Diagnostics;
using System.Text.Json;

public static class GVSettings
{
    private static readonly string SETTINGS_FPATH = "gitVis.json";
    public static GVSettingsData data { get; private set; }

    // try load file, else defaults
    static GVSettings()
    {
        data = new GVSettingsData();
        if (!Path.Exists(SETTINGS_FPATH))
        {
            Debug.WriteLine("CREATING DEFAULT SETTINGS FILE");
            saveSettings();
        }
        else
        {
            Debug.WriteLine("LOADING SETTINGS FILE");
            loadSettings();
        }
    }

    public static void debugPrintPath()
    {
        Debug.WriteLine("ROOT SETTINGS PATH : " + Path.GetFullPath(SETTINGS_FPATH));
    }

    public static void loadSettings()
    {
        string settingsStr = File.ReadAllText(SETTINGS_FPATH);
        GVSettingsData? nullableData = JsonSerializer.Deserialize<GVSettingsData>(settingsStr);
        if (nullableData == null)
        {
            throw new Exception("Settings file is invalid json");
        }
        else
        {
            data = nullableData;
        }
    }

    public static void saveSettings()
    {
        string settingsString = JsonSerializer.Serialize(data);
        File.WriteAllText(SETTINGS_FPATH, settingsString);
    }

    public class GVSettingsData
    {
        public bool rememberGitHubLogin { get; set; }
        public List<LocalTrackedDir> trackedLocalDirs { get; set; }

        public GVSettingsData(bool rememberGitHubLogin, List<LocalTrackedDir> trackedLocalDirs)
        {
            this.rememberGitHubLogin = rememberGitHubLogin;
            this.trackedLocalDirs = trackedLocalDirs;
        }

        public GVSettingsData()
        {
            rememberGitHubLogin = true;
            trackedLocalDirs = new List<LocalTrackedDir>();
        }
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
