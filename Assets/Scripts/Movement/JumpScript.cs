using UnityEngine;

public class JumpScript : MonoBehaviour
{
    // Get access to the correct Rigidbody2D component.
    public Rigidbody2D Rigidbody;
    public float JumpPower;
    public CreatureAnim anim;

    public GroundCheck GroundCheck;

    public KeyCode JumpKey;

    // Update is called once per frame
    void Update()
    {
        // Check to see if jump animation should play.
        anim.Jump(GroundCheck.IsGrounded);

        // Jump.
        if (Input.GetKeyDown(JumpKey) && GroundCheck.IsGrounded)
        {
            Rigidbody.linearVelocity += Vector2.up * JumpPower;
        }
    }
}
