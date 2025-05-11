using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 direction;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.zero;
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 inputDirection = new Vector2(moveX, moveY);

        if (inputDirection != Vector2.zero)
        {
            direction = inputDirection.normalized;

            if (!GameManager.Instance.HasTimerStarted())
            {
                GameManager.Instance.StartTimer();
            }
        }
        else
        {
            direction = Vector2.zero; // ?? Stop when no input
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = direction * moveSpeed;
    }
}