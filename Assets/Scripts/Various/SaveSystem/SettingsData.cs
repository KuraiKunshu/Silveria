using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SettingsData : ISavebleDataClass {



    #region DataToSave
    private string resolution;
    private List<string> availablePlatform;
    private List<string> availableDevice;
    #endregion


    public float CurrentFileVersion {
        get { return 1.1f; }
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
        if (availableDevice == null) {
            availableDevice = new List<string>();
            availableDevice.Add("Pad");
        }
        savedFileVersion = CurrentFileVersion;
    }

    public void OnCreation() {
        availablePlatform = new List<string>();
        availablePlatform.Add(Application.platform.ToString());
        resolution = "Pippo_Franco";
        availableDevice = new List<string>();
        availableDevice.Add("Pad");
        savedFileVersion = CurrentFileVersion;
    }

    public void OnDataDeselected() {
        //settings non lo hanno quasi mai, almeno che non mettete dei preset
    }

    public void OnDataSelected() {
        //adattare lo stato del gioco ai preset di settaggi selezionati
    }

    public void OnDelete() {
        //cancellato
    }

    public void OnLoadedFromDisk() {
        //caricato
    }

    public void OnPostSave() {
        //tutto quello che dovete fare DOPO che il file è stato salvato
    }

    public void OnPreSave() {
        //tutto quello che dovete fare PRIMA che il file venga salvato
    }
}
