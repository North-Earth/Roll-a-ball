using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Fields

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

    public void ToggleGamePause()
    {
        if (!scene.name.ToLower().Contains("menu"))
        {
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

    public string GetVersion() => $"version {Application.version}";

    public string GetProductName() => Application.productName;

    public void StartNewGame()
    {
        LoadScene(1);
    }

    public void LoadGame()
    {
        LoadScene(1);
    }

    public void RestartGame()
    {
        RestartScene();
    }

    public void ExitToMainMenu()
    {
        LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartNextLevel()
    {
        var sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        LoadScene(sceneBuildIndex + 1);
    }

    private void LoadScene(string sceneName)
    {
        if (scene.name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void LoadScene(int sceneBuildIndex)
    {
        if (scene.buildIndex != sceneBuildIndex)
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(scene.name);
    }

    #endregion


}
