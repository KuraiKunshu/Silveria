using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueSaveData : ISavebleDataClass
{

    #region DataToSave
    private List<uint> dialogueDisplayed;
    private List<uint> actionChoosed;
    #endregion


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
        return CurrentFileVersion == SavedFileVersion;
    }

    public void HandleVersionChanged() {
        savedFileVersion = CurrentFileVersion;
    }

    public void OnCreation() {
        dialogueDisplayed = new List<uint>();
        actionChoosed = new List<uint>();
        savedFileVersion = CurrentFileVersion;
    }

    public void OnDataDeselected() {
    }

    public void OnDataSelected() {
        Debug.Log("Mostro i dialoghi visti:");
        foreach (uint id in dialogueDisplayed) {
            Debug.Log(id);
        }
        Debug.Log("Mostro le azioni scelte");
        foreach (uint id in actionChoosed) {
            Debug.Log(id);
        }
    }


    public void OnDelete() {
    }

    public void OnLoadedFromDisk() {
    }

    public void OnPostSave() {
    }

    public void OnPreSave() {
    }
    #endregion

    #region HandleData 
    public bool DialogueDisplayed (uint dialogueID) {
        return dialogueDisplayed.Contains(dialogueID);
    }

    public bool ActionChoosed (uint actionID) {
        return actionChoosed.Contains(actionID);
    }

    public void SetDialogueDisplayed (uint dialogueID) {
        if (dialogueDisplayed.Contains(dialogueID)) return;
        dialogueDisplayed.Add(dialogueID);
    }

    public void SetActionChoosed (uint actionID) {
        if (actionChoosed.Contains(actionID)) return;
        actionChoosed.Add(actionID);
    }
    #endregion

}
