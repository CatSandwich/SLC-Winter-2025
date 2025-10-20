using UnityEditor.Rendering;
using UnityEngine;

public class TerminalVelocity : MonoBehaviour
{
    public Rigidbody2D Rigidbody;

    public float terminalVelocity;

    // Update is called once per frame
    void Update()
    {
        if (Rigidbody.linearVelocity.y < terminalVelocity)
        {
            Vector2 temp = Rigidbody.linearVelocity;

            temp.y = terminalVelocity;

            Rigidbody.linearVelocity = temp;
        }
    }
}
