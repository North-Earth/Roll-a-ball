using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{
    #region Fields

    public GameObject gameMenu;

    #endregion

    #region Methods

    private void Start()
    {
        gameMenu.SetActive(false);
    }

    [System.Obsolete]
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            PauseGame();
        }
    }

    [System.Obsolete]
    private void PauseGame()
    {
        gameMenu.SetActive(!gameMenu.active);
        
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.001f;
        }
        else if (Time.timeScale == 0.001f)
        {
            Debug.Log("high");
            Time.timeScale = 1.0f;
        }
    }

    [System.Obsolete]
    public void ContinueGame_OnClick()
    {
        PauseGame();
    }

    public void ExitToMenu_OnClick()
    {
        LoadScene("DemoMenu");
    }

    public void ExitGame_OnClick()
    {
        Application.Quit();
    }

    private void LoadScene(string sceneName)
    {
        // Return the current Active Scene in order to get the current Scene name.
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }

    #endregion
}
