using UnityEngine;

public static class SaveSystemConfiguration {

    private const string settingsPath = "/Settings/";
    private const string gameDataPath = "/Data/";

    private const string settingsFileName = "Settings.file";
    private const string gameDataNameAffix = "GameData_";
    private const string gameDataNameSuffix = ".file";

    private const int gameDataSlotsNumber = 3;

    public static string RootsPath {
        get { return Application.persistentDataPath; }
    }

    public static string SettingsFolderPath {
        get { return RootsPath + settingsPath; }
    }
    public static string SettingsFilePath {
        get { return SettingsFolderPath + settingsFileName; }
    }
    public static string GameDataFolderPath {
        get { return RootsPath + gameDataPath; }
    }

    public static int GameDataSlotsNumber {
        get { return gameDataSlotsNumber; }
    }

    public static string GetGameDataPath (int slot) {
        return GameDataFolderPath + gameDataNameAffix + slot.ToString() + gameDataNameSuffix;
    }
}
