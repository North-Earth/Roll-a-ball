using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Fields

    public GameObject gameMenu;
    public GameObject overlay;
    public GameManager gameManager;

    public Text productNameText;
    public Text vesionText;

    public Text gameInfoText;
    public Text countText;

    private int count;

    #endregion

    #region Methods

    // PreStart
    private void Awake()
    {
        vesionText.text = gameManager.GetVersion();
        productNameText.text = gameManager.GetProductName();
        SetEnableGameMenu(false);
    }

    // Start is called before the first frame update
    private void Start()
    {
        count = 0; //TODO: Save count.
        SetCountText();
    }

    // Update is called once per frame
    private void Update()
    {
        KeyDownCheck();
    }

    private void KeyDownCheck()
    {
        if (Input.GetKeyDown("escape"))
        {
            SetEnableGameMenu(!gameMenu.activeSelf);
        }
    }

    private void SetEnableGameMenu(bool enable)
    {
        overlay.SetActive(!enable);
        gameMenu.SetActive(enable);
    }

    private void SetGameInfoText(string text)
    {
        gameInfoText.enabled = true;
        gameInfoText.text = text;
    }

    #region Button Clicks

    public void Resume() => SetEnableGameMenu(false);

    public void Restart() => gameManager.RestartGame();

    public void Options()
    {
        /* TODO: Create options menu */
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    public void ExitToMenu() => gameManager.ExitToMainMenu();

    public void ExitGame() => gameManager.ExitGame();

    #endregion

    #region Gameplay

    public void PickUp()
    {
        count += 1;
        SetCountText();
    }

    public void SetCountText()
    {
        if (countText != null)
        {
            countText.text = $"Count: {count}";
        }
    }

    public void FinishGame()
    {
        //SetGameInfoText("You Win!\n" +
        //    $"You pick {count}");
        gameManager.StartNextLevel();
    }

    public void EndGame()
    {
        SetGameInfoText("You Lose!");
        var image = overlay.GetComponent<Image>();
        image.color = new Color(1,0,0,0.3f);
    }

    #endregion

    #endregion
}
