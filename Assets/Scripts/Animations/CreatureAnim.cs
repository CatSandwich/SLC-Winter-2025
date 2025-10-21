using UnityEngine;

public class CreatureAnim : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sr;
    int spriteDirection = 0;

    // Test for possessed idle animation.
    public void BecomePossessed(bool isPossessed)
    {
        anim.SetBool("isPossessed", isPossessed);
    }

    // Test for jumping animation.
    public void Jump(bool isGrounded)
    {
        anim.SetBool("isGrounded", isGrounded);
    }

    // Test for moving animation.
    public void Move(bool isMoving, int direction)
    {
        if (spriteDirection != direction)
        {
            sr.flipX = true;
        }
        else if (spriteDirection == direction)
        {
            sr.flipX = false;
        }
        anim.SetBool("isMoving", isMoving);
    }
}
