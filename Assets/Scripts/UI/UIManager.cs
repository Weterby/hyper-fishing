using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private ScoreData scoreData;
    [SerializeField]
    private GameObject menuPanel;

    #endregion

    #region Private Fields

    private bool menuVisible;

    #endregion

    #region Unity Callbacks

    private void Update()
    {
        scoreText.text = scoreData.Score.ToString("000");

        if (!Input.GetKeyDown(KeyCode.Escape))
        {
            return;
        }

        if (!menuVisible)
        {
            ShowMenu();
        }
        else
        {
            CloseMenu();
        }
    }

    #endregion

    #region Public Methods

    public void ShowMenu()
    {
        Time.timeScale = 0f;
        menuVisible = true;
        menuPanel.SetActive(true);
    }

    public void CloseMenu()
    {
        Time.timeScale = 1f;
        menuVisible = false;
        menuPanel.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    #endregion
}