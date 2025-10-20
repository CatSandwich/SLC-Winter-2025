using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float HorizontalSpeed;

    void Update()
    {
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
