using System;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityEnum {
    Collision,
    Move,
    Jump,
    Dash,
    AndSoOn
}

[Serializable]
public class PlayerSavedData : ISavebleDataClass
{

    #region AttributeToSave
    private float maxHP;
    private float currentHP;
    private float maxEnergy;
    private float currentEnergy;
    private List<AbilityEnum> unlockedAbilities;
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
        return SavedFileVersion == CurrentFileVersion;
    }

    public void HandleVersionChanged() {
        //Fai tuttecose

        savedFileVersion = CurrentFileVersion;

    }

    public void OnCreation() {
        maxEnergy = 3;
        currentEnergy = 1;
        maxHP = 5;
        currentHP = 2;
        unlockedAbilities = new List<AbilityEnum>();
        unlockedAbilities.Add(AbilityEnum.Collision);
        unlockedAbilities.Add(AbilityEnum.Move);
        savedFileVersion = CurrentFileVersion;
    }

    public void OnDataDeselected() {
        //Faccio cose
    }

    public void OnDataSelected() {
        Debug.Log("Display max current hp and max current energy: " + MaxHP + " " + CurrentHP + " " + MaxEnergy + " " + CurrentEnergy);
        Debug.Log("Displaying unlocked abilities");
        foreach (AbilityEnum ability in unlockedAbilities) {
            Debug.Log(ability);
        }
    }


    public void OnDelete() {
        //Prima di essere cacnellato
    }

    public void OnLoadedFromDisk() {
    }

    public void OnPostSave() {
    }

    public void OnPreSave() {
    }
    #endregion

    #region HandleData
    public float MaxHP {
        get { return maxHP; }
    }
    public float CurrentHP {
        get { return currentHP; }
    }
    public float MaxEnergy {
        get { return maxEnergy; }
    }
    public float CurrentEnergy {
        get { return currentEnergy; }
    }

    public bool AbilityUnlocked (AbilityEnum ability) {
        return unlockedAbilities.Contains(ability);
    }
    public void UnlockAbility (AbilityEnum ability) {
        if (unlockedAbilities.Contains(ability)) return;
        unlockedAbilities.Add(ability);
    }
    #endregion

}
