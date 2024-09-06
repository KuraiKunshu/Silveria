using UnityEngine;
using static PlayerSavedData;

public class DemoTestData : MonoBehaviour {

    [SerializeField]
    private GameObject[] saveSlotButtons;

    private void Start() {
        SaveSystem.LoadAllSlotData();
        for (int i = 0; i < saveSlotButtons.Length; i++) {
            saveSlotButtons[i].SetActive(SaveSystem.GameDataExists(i));
        }
    }


    public void CreateSaveSlot(int slotIndex) {
        SaveSystem.CreateGameData(slotIndex);
    }

    public void SelectSaveSlot(int slotIndex) {
        SaveSystem.SelectGameData(slotIndex);
    }

    public void AddDialogueDisplayed(int dialogueID) {
        SaveSystem.ActiveGameData.DialogueSavedData.SetDialogueDisplayed((uint)dialogueID);
    }

    public void AddActionChoosen(int actionID) {
        SaveSystem.ActiveGameData.DialogueSavedData.SetActionChoosed((uint)actionID);
    }

    public void UnlockPlayerAbility(int ability) {
        SaveSystem.ActiveGameData.PlayerSavedData.UnlockAbility((AbilityEnum)ability);
    }

    public void Save() {
        SaveSystem.SaveActiveGameData();
    }

}

