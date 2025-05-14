using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip keyPickup;
      //added audio test
    public AudioManager audioManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
             // Play key pickup sound
            Debug.Log("Key collected!"); // Confirm collection
            GameManager.Instance.CollectKey();
            audioManager.PlaySFX(audioManager.keyPickup);
            Destroy(other.gameObject);

            ScoreManager.Instance.AddPoint(); // Update score
        }

        if (other.CompareTag("Exit"))
        {
            Debug.Log("Reached Exit!");
            GameManager.Instance.PlayerEscaped();
        }
    }
}