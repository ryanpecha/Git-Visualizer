using System.Diagnostics;
using System.Text.Json;
using System.Xml;
using System;

public static class GVSettings
{
    private static readonly string SETTINGS_FPATH = "GitVisualizer.settings.json";
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
        GVSettingsData? nullableData = System.Text.Json.JsonSerializer.Deserialize<GVSettingsData>(
            settingsStr
        );
        if (nullableData == null)
        {
            Debug.WriteLine("Settings file is invalid json, loading defaults");
            File.Delete(SETTINGS_FPATH);
            data = new GVSettingsData();
        }
        else
        {
            data = nullableData;
        }
    }

    public static void saveSettings()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string settingsString = JsonSerializer.Serialize(data, options);
        File.WriteAllText(SETTINGS_FPATH, settingsString);
    }

    public class GVSettingsData
    {
        public bool rememberGitHubLogin { get; set; }
        public List<LocalTrackedDir> trackedLocalDirs { get; set; }
        public string? liveRepostoryPath {get; set;}

        public GVSettingsData(bool rememberGitHubLogin, List<LocalTrackedDir> trackedLocalDirs, string liveRepostoryPath)
        {
            this.rememberGitHubLogin = rememberGitHubLogin;
            this.trackedLocalDirs = trackedLocalDirs;
            this.liveRepostoryPath = liveRepostoryPath;
        }

        public GVSettingsData()
        {
            rememberGitHubLogin = true;
            trackedLocalDirs = new List<LocalTrackedDir>();
            liveRepostoryPath = null;
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

    public override string ToString()
    {
        string recursiveIndicator = recursive ? "Recursive" : "Not Recursive";
        return path + $" [{recursiveIndicator}]";
    }
}
