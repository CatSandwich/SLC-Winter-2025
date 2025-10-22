using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float HorizontalSpeed;
    public CreatureAnim anim;
    private int currDirection;

    void Update()
    {
        // Left move.
        if (Input.GetKey(KeyCode.A))
        {
            // A currDirection value of 1 will make the sprite left-facing.
            currDirection = 1;
            anim.Move(true, currDirection, HorizontalSpeed);
            transform.position += Vector3.left * HorizontalSpeed * Time.deltaTime;
        }

        // Right move.
        if (Input.GetKey(KeyCode.D))
        {
            // A currDirection value of 1 will make the sprite right-facing.
            currDirection = 0;
            anim.Move(true, currDirection, HorizontalSpeed);
            transform.position += Vector3.right * HorizontalSpeed * Time.deltaTime;
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            anim.Move(false, currDirection, HorizontalSpeed);
        }
    }
}
