using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private ScoreData scoreData;
    [SerializeField] private GameObject menuPanel;
    private bool menuVisible = false;
    private void Update()
    {
        scoreText.text = scoreData.Score.ToString("000");

        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        
        if (!menuVisible)
        {
            ShowMenu();
        }
        else
        {
            CloseMenu();
        }
    }

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
}