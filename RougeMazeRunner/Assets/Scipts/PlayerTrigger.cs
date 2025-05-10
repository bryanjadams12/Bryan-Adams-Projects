using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            GameManager.Instance.CollectKey();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Exit"))
        {
            GameManager.Instance.PlayerEscaped();
        }
    }
}