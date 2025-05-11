using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            Debug.Log("Key collected!"); // Confirm collection
            GameManager.Instance.CollectKey();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Exit"))
        {
            Debug.Log("Reached Exit!");
            GameManager.Instance.PlayerEscaped();
        }
    }
}