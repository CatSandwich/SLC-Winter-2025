using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Get access to the correct Rigidbody2D component.
    public Rigidbody2D Rigidbody;
    public float JumpPower;
    public float HorizontalSpeed;

    public KeyCode JumpKey;

    private void Update()
    {
        // Jump.
        if (Input.GetKeyDown(JumpKey))
        {
            Rigidbody.linearVelocity += Vector2.up * JumpPower;
        }

        // Left move.
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * HorizontalSpeed * Time.deltaTime;
        }

        // Right move.
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * HorizontalSpeed * Time.deltaTime;
        }
    }
}
