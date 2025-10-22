using UnityEngine;

public class CreatureAnim : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sr;
    private int spriteDirection = 0;

    private float timer;

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
    public void Move(bool isMoving, int direction, float speed)
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

        // Test for walking sound effects.
        if (isMoving && anim.GetBool("isGrounded") && speed == 0)
        {
            timer = 0;
        }
        else if (isMoving && anim.GetBool("isGrounded") && speed == 6)
        {
            timer += Time.deltaTime;
            if (timer > 3f / speed)
            {
                int randNum = Random.Range(0, 3);
                SoundManager.instance.PlaySFX(SoundManager.instance.audioClips[randNum], SoundManager.instance.sfxSource);
                timer = 0;
            }
        }
    }
}
