using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SaveSlotsMenu : Menu
{
    [Header("Menu Navigation")]

    [SerializeField] private SaveMenu saveMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button backButton;


    private SaveSlot[] saveSlots;


    private bool isLoadingGame = false;


    private void Awake()
    {
        saveSlots = this.GetComponentsInChildren<SaveSlot>();
    }

    public void OnBackClicked()
    {
        saveMenu.ActivateMenu();
        this.DeactivateMenu();
    }

    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        // disable all buttons
        DisableMenuButtons();

        // update the selected profile id to be used for data persistence
        DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());

        if (!isLoadingGame)
        {
            // create a new game - which will initialize our data to a clean state
            DataPersistenceManager.instance.NewGame();
        }

        // create a new game - which will initialize our data to a clean slate
        DataPersistenceManager.instance.NewGame();

        DataPersistenceManager.instance.SaveGame();

        // Load the scene
        SceneManager.LoadSceneAsync("GameState");

    }


    public void ActivateMenu(bool isLoadingGame)
    {
        // set this menu to be active
        this.gameObject.SetActive(true);

        // set mode
        this.isLoadingGame = isLoadingGame;

        // Load all of the profiles that exist
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData();

        // Loop through each save slot in the UI and set the content appropriately
        foreach (SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
            saveSlot.SetData(profileData);
            if (profileData == null && isLoadingGame)
            {
                saveSlot.SetInteractable(false);
            }
            else
            {
                saveSlot.SetInteractable(true);
            }
        }
    }


    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

    private void DisableMenuButtons()
    {
        foreach (SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }
        backButton.interactable = false;
    }
}
