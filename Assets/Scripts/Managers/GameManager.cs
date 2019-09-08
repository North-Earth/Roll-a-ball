using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Fields

    public GameObject gameMenu;
    public GameObject UI;
    public Text pauseText;

    private Scene scene;
    #endregion

    #region Methods

    private void Awake()
    {
        // Return the current Active Scene in order to get the current Scene name.
        scene = SceneManager.GetActiveScene();
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void LateUpdate()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    [System.Obsolete]
    public void ToggleGameMenu()
    {
        if (gameMenu != null)
        {
            UI.SetActive(!UI.active);
            gameMenu.SetActive(!gameMenu.active);
        }
    }

    public void ToggleGamePause()
    {
        if (!scene.name.ToLower().Contains("menu"))
        {
            pauseText.enabled = !pauseText.enabled;

            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0.0f;
            }
            else if (Time.timeScale == 0.0f)
            {
                Time.timeScale = 1.0f;
            }
        }
    }

    [System.Obsolete]
    public void ToggleUI()
    {
        if (UI != null)
        {
            UI.SetActive(!UI.active);
        }
    }

    public void LoadScene(string sceneName)
    {
        if (scene.name != sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }

    public void LoadScene(int sceneBuildIndex)
    {
        if (scene.buildIndex != sceneBuildIndex)
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("DemoMenu", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }

    #endregion


}
