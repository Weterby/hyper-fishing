using UnityEngine;

public class FishCollector : MonoBehaviour
{
    [SerializeField] private ScoreData scoreData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            Destroy(collision.gameObject);
            scoreData.Score++;
        }
    }
}