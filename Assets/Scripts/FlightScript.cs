using UnityEngine;

public class FlightScript : MonoBehaviour
{
    // Get access to the correct Rigidbody2D component.
    public Rigidbody2D Rigidbody;
    public float JumpPower;

    public KeyCode JumpKey;

    // Update is called once per frame
    void Update()
    {
        // Jump.
        if (Input.GetKeyDown(JumpKey))
        {
            Rigidbody.linearVelocity += Vector2.up * JumpPower;
        }
    }
}