using UnityEngine;

public class FlightScript : MonoBehaviour
{
    // Get access to the correct Rigidbody2D component.
    public Rigidbody2D Rigidbody;
    public float JumpPower;

    public float FlightGravity;

    public KeyCode JumpKey;
    
    // Update is called once per frame
    void Update()
    {
        // Up.
        if (Input.GetKey(JumpKey))
        {
            transform.position += Vector3.up * JumpPower * Time.deltaTime;
        }
        // Down.
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += Vector3.down * JumpPower * Time.deltaTime;
        }
        //Gravity
        else
        {
            transform.position += Vector3.down * FlightGravity * Time.deltaTime;
        }
    }
}