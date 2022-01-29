using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private ScoreData scoreData;

    private void Update()
    {
        scoreText.text = scoreData.Score.ToString("000");
    }
}