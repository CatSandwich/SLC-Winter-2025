using UnityEngine;

public class CreatureAnim : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sr;
    int spriteDirection = 0;

    public void BecomePossessed(bool isPossessed)
    {
        anim.SetBool("isPossessed", isPossessed);
    }

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
