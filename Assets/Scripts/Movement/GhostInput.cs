using UnityEngine;

public class GhostInput : MonoBehaviour
{
    public float movementSpeed;
    public CreatureAnim ghostAnim;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            ghostAnim.Move(true, 0, 0);
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            ghostAnim.Move(true, 1, 0);
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            ghostAnim.Move(false, 0, 0);
        }
    }
}
