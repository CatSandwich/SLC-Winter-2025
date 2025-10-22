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
    public void Jump(bool isGrounded, float jumpPower)
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
        switch (speed)
        {
            case 4: // Giant
                if (isMoving && anim.GetBool("isGrounded"))
                {
                    if (timer == 0)
                    {
                        int randNum = Random.Range(0, 3);
                        SoundManager.instance.PlaySFX(SoundManager.instance.audioClips[randNum], SoundManager.instance.sfxSource, Random.Range(0.4f, 0.6f));
                    }
                    timer += Time.deltaTime;
                    if (timer > 3f / 6)
                    {
                        timer = 0;
                    }
                }
                break;

            case 6: // Player
                if (isMoving && anim.GetBool("isGrounded"))
                {
                    if (timer == 0)
                    {
                        int randNum = Random.Range(0, 3);
                        SoundManager.instance.PlaySFX(SoundManager.instance.audioClips[randNum], SoundManager.instance.sfxSource, Random.Range(0.9f, 1.1f));
                    }
                    timer += Time.deltaTime;
                    if (timer > 3f / 6)
                    {
                        timer = 0;
                    }
                }
                break;
            
            case 7: // Skeleton
                if (isMoving && anim.GetBool("isGrounded"))
                {
                    if (timer == 0)
                    {
                        int randNum = Random.Range(0, 3);
                        SoundManager.instance.PlaySFX(SoundManager.instance.audioClips[randNum], SoundManager.instance.sfxSource, Random.Range(1.4f, 1.6f));
                    }
                    timer += Time.deltaTime;
                    if (timer > 3f / 12)
                    {
                        timer = 0;
                    }
                }
                break;

            case 8: // Rat
                if (isMoving && anim.GetBool("isGrounded"))
                {
                    if (timer == 0)
                    {
                        int randNum = Random.Range(4, 7);
                        SoundManager.instance.PlaySFX(SoundManager.instance.audioClips[randNum], SoundManager.instance.sfxSource, Random.Range(2.4f, 2.6f));
                    }
                    timer += Time.deltaTime;
                    if (timer > 3f / 24)
                    {
                        timer = 0;
                    }
                }
                break;

            default:
                if (isMoving && anim.GetBool("isGrounded"))
                {
                    timer = 0;
                }
                break;
        }
        if (!isMoving || !anim.GetBool("isGrounded"))
        {
            timer = 0;
        }
    }
}
