using UnityEngine;

[CreateAssetMenu(menuName = "UI/Score Data", fileName = "ScoreData")]
public class ScoreData : ScriptableObject
{
    #region Serialized Fields

    [SerializeField]
    private int score;

    #endregion

    #region Public Properties

    public int Score { get => score; set => score = value; }

    #endregion
}