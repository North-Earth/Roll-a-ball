using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Fields

    public Text version;
    public Text productName;
    public Text countText;
    public Text winText;

    public GameObject observer;
    private GameManager gameManager;

    private int count;

    #endregion

    #region Methods

    private void Awake()
    {
        version.text = $"version: {Application.version}";
        productName.text = Application.productName;
        gameManager = observer.GetComponent<GameManager>();
    }

    private void Start()
    {
        count = 0;
        SetCountText();
    }

    [System.Obsolete]
    private void Update()
    {
        KeyDownCheck();
    }

    [System.Obsolete]
    private void KeyDownCheck()
    {
        if (Input.GetKeyDown("escape"))
            gameManager.ToggleGameMenu();
        else if (Input.GetKeyDown("p"))
            gameManager.ToggleGamePause();
        else if (Input.GetKeyDown("u"))
            gameManager.ToggleUI();
    }


    public void PickUp(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }
    public void SetCountText()
    {
        if (countText != null)
        {
            countText.text = $"Count: {count}";
            if (count >= 8)
            {
                winText.enabled = true;
                winText.text = "You Win!";
            }
        }
    }

    public void PlayNewGame()
    {
        gameManager.LoadScene(1);
    }

    public void PlayGame()
    {
        gameManager.LoadScene("");
    }

    public void RestartGame()
    {
        gameManager.RestartScene();
    }

    [System.Obsolete]
    public void Continue()
    {
        gameManager.ToggleUI();
    }

    public void ExitToMainMenu()
    {
        gameManager.ExitToMainMenu();
    }
    public void Exit()
    {
        gameManager.Exit();
    }




    #endregion

}
