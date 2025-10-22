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
        anim.Jump(GroundCheck.IsGrounded, JumpPower);

        // Jump.
        if (Input.GetKeyDown(JumpKey) && GroundCheck.IsGrounded)
        {
            Rigidbody.linearVelocity += Vector2.up * JumpPower;

            // Test for walking sound effects.
            switch (JumpPower)
            {
                case 3: // Rat
                    SoundManager.instance.PlaySFX(SoundManager.instance.audioClips[13], SoundManager.instance.sfxSource, Random.Range(2.4f, 2.6f));
                    break;

                case 4: // Giant
                    int randNum = Random.Range(14, 15);
                    SoundManager.instance.PlaySFX(SoundManager.instance.audioClips[randNum], SoundManager.instance.sfxSource, Random.Range(1.0f, 1.2f));
                    break;

                case 8: // Player
                    randNum = Random.Range(10, 12);
                    SoundManager.instance.PlaySFX(SoundManager.instance.audioClips[randNum], SoundManager.instance.sfxSource, Random.Range(1.0f, 1.2f));
                    break;

                case 9: // Skeleton
                    SoundManager.instance.PlaySFX(SoundManager.instance.audioClips[16], SoundManager.instance.sfxSource, Random.Range(1.3f, 1.7f));
                    break;

                default:
                    break;
            }
        }
    }
}
