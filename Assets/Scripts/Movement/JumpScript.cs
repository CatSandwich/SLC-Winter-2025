using UnityEngine;

public class JumpScript : MonoBehaviour
{
    // Get access to the correct Rigidbody2D component.
    public Rigidbody2D Rigidbody;
    public float JumpPower;

    public GroundCheck GroundCheck;

    public KeyCode JumpKey;

    // Update is called once per frame
    void Update()
    {
        // Jump.
        if (Input.GetKeyDown(JumpKey) && GroundCheck.IsGrounded)
        {
            Rigidbody.linearVelocity += Vector2.up * JumpPower;
        }
    }
}
