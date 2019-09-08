using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    #region Fields

    public Text version;
    public Text productName;

    #endregion

    #region Methods

    private void Start()
    {
        version.text = $"version: {Application.version}";
        productName.text = Application.productName;
    }

    public void StartGame_OnClick()
    {
        LoadScene("DemoGame");
    }

    public void Quit_OnClick()
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
