using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    #region Fields

    public GameManager gameManager;
    public Text headerText;
    public Text versionText;

    #endregion

    #region Methods

    public void Awake()
    {
        headerText.text = gameManager.GetProductName();
        versionText.text = gameManager.GetVersion();
    }

    public void StartNewGame()
    {
        gameManager.StartNewGame();
    }

    public void LoadGame()
    {
        gameManager.LoadGame();
    }

    public void ExitGame()
    {
        gameManager.ExitGame();
    }

    #endregion
}
