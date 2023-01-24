using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveMenu : Menu
{
    [Header("Menu Navigation")]

    [SerializeField] private SaveSlotsMenu saveSlotsMenu;


    [Header("Menu Buttons")]

    [SerializeField] private Button newGameButton;

    [SerializeField] private Button continueGameButton;


    private void Start()
    {
        if (!DataPersistenceManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }
    }

    public void OnNewGameClicked()
    {
        saveSlotsMenu.ActivateMenu(false);
        this.DeactivateMenu();
    }


    public void OnLoadGameClicked()
    {
        saveSlotsMenu.ActivateMenu(true);
        DataPersistenceManager.instance.SaveGame();
        this.DeactivateMenu();
    }


    public void OnContinueGameClicked()
    {
        DisableMenuButtons();
        // Load the next scene
        SceneManager.LoadSceneAsync("GameState");
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }

    public void returnToMain()
    {
       // SceneManager.LoadSceneAsync("MainMenu");
    }

    public void ActivateMenu()
    {
        this.gameObject.SetActive(true);
    }


    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

}
