using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class StandaloneSaveSystem : ISaveSystem {


    private SettingsData settingsData;
    private GameSavedData[] allDatas;

    public GameSavedData ActiveGameData {
        get;
        private set;
    }

    private int currentSlotIndex;

    public void Initialize() {
        allDatas = new GameSavedData[SaveSystemConfiguration.GameDataSlotsNumber];
        if (!Directory.Exists(SaveSystemConfiguration.SettingsFolderPath)) {
            Directory.CreateDirectory(SaveSystemConfiguration.SettingsFolderPath);
        }
        if (!Directory.Exists(SaveSystemConfiguration.GameDataFolderPath)) {
            Directory.CreateDirectory(SaveSystemConfiguration.GameDataFolderPath);
        }

        if (!SettingsDataExists()) {
            CreateSettingsData();
        } else {
            settingsData = LoadISavableData<SettingsData>(SaveSystemConfiguration.SettingsFilePath);
        }
    }


    #region SettingsData
    public void CreateSettingsData() {
        settingsData = CreateISavebleData<SettingsData>();
        SaveSettingsData();
    }

    public bool SettingsDataExists() {
        return File.Exists(SaveSystemConfiguration.SettingsFilePath);
    }


    public void SaveSettingsData() {
        SaveISavebleData<SettingsData>(SaveSystemConfiguration.SettingsFilePath, settingsData);
    }



    public void DeleteSettingsData() {
        DeleteISavebleData<SettingsData>(SaveSystemConfiguration.SettingsFilePath, settingsData);
    }
    #endregion

    public void CreateGameData(int slotIndex) {
        allDatas[slotIndex] = CreateISavebleData<GameSavedData>();
        SaveISavebleData<GameSavedData>(SaveSystemConfiguration.GetGameDataPath(slotIndex), allDatas[slotIndex]);
    }


    public void DeleteGameData(int slotIndex) {
        DeleteISavebleData<GameSavedData>(SaveSystemConfiguration.GetGameDataPath(slotIndex), allDatas[slotIndex]);
    }

    public bool GameDataExists(int slotIndex) {
        return File.Exists(SaveSystemConfiguration.GetGameDataPath(slotIndex));
    }

    public void LoadAllSlotData() {
        for (int i = 0; i < allDatas.Length; i++) {
            string path = SaveSystemConfiguration.GetGameDataPath(i);
            if (GameDataExists(i)) {
                allDatas[i] = LoadISavableData<GameSavedData>(path);
            } else {
                allDatas[i] = null;
            }
        }
    }

    public void SaveActiveGameData() {
        SaveISavebleData<GameSavedData>(SaveSystemConfiguration.GetGameDataPath(currentSlotIndex), ActiveGameData);
    }


    public void SelectGameData(int slotIndex) {
        if (ActiveGameData != null) {
            ActiveGameData.OnDataDeselected();
        }
        if (slotIndex == -1) {
            ActiveGameData = null;
            currentSlotIndex = -1;
            return;
        }
        ActiveGameData = allDatas[slotIndex];
        ActiveGameData.OnDataSelected();
        currentSlotIndex = slotIndex;
    }


    #region WrapperSavebleData
    private static T CreateISavebleData<T> () where T : ISavebleDataClass, new () {
        T data = new T();
        data.OnCreation();
        return data;
    }

    private static void DeleteISavebleData<T>(string path, ISavebleDataClass data) where T: ISavebleDataClass {
        data.OnDelete();
        File.Delete(path);
    }

    private T LoadISavableData<T> (string path) where T : ISavebleDataClass {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.OpenOrCreate);
        T data = (T)bf.Deserialize(file);
        file.Close();
        if (!data.CheckVersion()) {
            data.HandleVersionChanged();
        }
        data.OnLoadedFromDisk();
        return data;
    }

    private void SaveISavebleData<T>(string path, ISavebleDataClass dataToSave) where T: ISavebleDataClass {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.OpenOrCreate);
        dataToSave.OnPreSave();
        bf.Serialize(file, dataToSave.InstanceToSave);
        dataToSave.OnPostSave();
        file.Close();
    }
    #endregion
}
