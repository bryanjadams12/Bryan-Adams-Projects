using UnityEngine;

public class Key : MonoBehaviour
{
    public AudioManager audioManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectKey();
            audioManager.PlaySFX(audioManager.keyPickup);
            Destroy(gameObject);
            ScoreManager.Instance.AddPoint();
        }
    }
}
