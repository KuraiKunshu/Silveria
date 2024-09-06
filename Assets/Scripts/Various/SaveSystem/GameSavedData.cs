using System;
using System.Collections.Generic;

[Serializable]
public class GameSavedData : ISavebleDataClass
{

    private List<ISavebleDataClass> savebleDatas;

    #region Interface
    public float CurrentFileVersion {
        get { return 1.0f; }
    }

    private float savedFileVersion;
    public float SavedFileVersion {
        get { return savedFileVersion; }
    }

    public object InstanceToSave {
        get { return this; }
    }

    public bool CheckVersion() {
        return SavedFileVersion == CurrentFileVersion;
    }

    public void HandleVersionChanged() {
        //fai cose
        savedFileVersion = CurrentFileVersion;
    }

    public void OnCreation() {
        savebleDatas = new List<ISavebleDataClass>();
        PlayerSavedData playerSavedData = new PlayerSavedData();
        savebleDatas.Add(playerSavedData);
        DialogueSaveData dialogueData = new DialogueSaveData();
        savebleDatas.Add(dialogueData);

        foreach (ISavebleDataClass data in savebleDatas) {
            data.OnCreation();
        }
    }

    public void OnDataDeselected() {
        foreach (ISavebleDataClass data in savebleDatas) {
            data.OnDataDeselected();
        }
    }

    public void OnDataSelected() {
        foreach (ISavebleDataClass data in savebleDatas) {
            data.OnDataSelected();
        }
    }

    public void OnDelete() {
        foreach (ISavebleDataClass data in savebleDatas) {
            data.OnDelete();
        }
    }

    public void OnLoadedFromDisk() {
        foreach (ISavebleDataClass data in savebleDatas) {
            data.OnDelete();
        }
    }

    public void OnPostSave() {
        foreach (ISavebleDataClass data in savebleDatas) {
            data.OnPostSave();
        }
    }

    public void OnPreSave() {
        foreach (ISavebleDataClass data in savebleDatas) {
            data.OnPreSave();
        }
    }
    #endregion

    #region WrapData
    public PlayerSavedData PlayerSavedData {
        get { return (PlayerSavedData)savebleDatas[0]; }
    }
    public DialogueSaveData DialogueSavedData {
        get { return (DialogueSaveData)savebleDatas[1]; }
    }
    #endregion

}
