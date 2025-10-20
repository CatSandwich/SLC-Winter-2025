using UnityEngine;

public class FlightScript : MonoBehaviour
{
    // Get access to the correct Rigidbody2D component.
    public Rigidbody2D Rigidbody;
    public float JumpPower;

    //public GroundCheck GroundCheck;

    public KeyCode JumpKey;

    // Update is called once per frame
    void Update()
    {
        /*while (!(GroundCheck.IsGrounded))
        {
            transform.position += Vector3.down * 5;
        }*/

        // Up.
        if (Input.GetKey(JumpKey))
        {
            transform.position += Vector3.up * JumpPower * Time.deltaTime;
        }

        // Down.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += Vector3.down * JumpPower * Time.deltaTime;
        }
    }
}