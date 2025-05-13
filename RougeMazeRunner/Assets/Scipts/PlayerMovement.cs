using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 direction;
    private Rigidbody2D rb;
    private bool movementEnabled = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.zero;
    }

    private void Update()
    {
        if (!movementEnabled)
        {
            direction = Vector2.zero;
            return;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 inputDirection = new Vector2(moveX, moveY);

        if (inputDirection != Vector2.zero)
        {
            direction = inputDirection.normalized;

            // Only start the timer if it's not started AND game isn't ended
            if (!GameManager.Instance.HasTimerStarted() && !GameManager.Instance.gameEnded)
            {
                GameManager.Instance.StartTimer();
            }
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = direction * moveSpeed;
    }

    public void SetMovementEnabled(bool enabled)
    {
        movementEnabled = enabled;
        if (!enabled)
        {
            rb.linearVelocity = Vector2.zero; // Stop any ongoing movement immediately
        }
    }
}