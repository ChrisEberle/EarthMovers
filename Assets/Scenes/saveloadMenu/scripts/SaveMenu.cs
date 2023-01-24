using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveMenu : MonoBehaviour
{
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
        DisableMenuButtons();
        // create a new game - which will initialize our game data
        DataPersistenceManager.instance.NewGame();
        // Load the gameplay scene
        SceneManager.LoadSceneAsync("GameState");
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

}
