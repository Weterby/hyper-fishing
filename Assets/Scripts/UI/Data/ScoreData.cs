using UnityEngine;

[CreateAssetMenu(menuName = "UI/Score Data", fileName = "ScoreData")]
public class ScoreData : ScriptableObject
{
    [SerializeField] private int score;

    public int Score
    {
        get => score;
        set => score = value;
    }
}