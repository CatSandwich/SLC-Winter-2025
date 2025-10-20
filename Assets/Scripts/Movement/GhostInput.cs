using UnityEngine;

public class GhostInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * 3 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * 3 * Time.deltaTime;
        }
    }
}
