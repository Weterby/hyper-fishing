using UnityEngine;

public class FishCollector : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private ScoreData scoreData;

    #endregion

    #region Unity Callbacks

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            Destroy(collision.gameObject);
            scoreData.Score++;
        }
    }

    #endregion
}