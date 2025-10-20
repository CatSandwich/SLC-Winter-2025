using UnityEngine;

public class FasterDown : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public float UpGravityScale;
    public float DownGravityScale;

    private void Update()
    {
        if (Rigidbody.linearVelocity.y < 0)
        {
            Rigidbody.gravityScale = DownGravityScale;
        }

        if (Rigidbody.linearVelocity.y > 0)
        {
            Rigidbody.gravityScale = UpGravityScale;
        }
    }
}
