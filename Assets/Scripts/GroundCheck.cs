using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GroundCheck : MonoBehaviour
{
    public bool IsGrounded => _groundOverlaps > 0;

    private int _groundOverlaps;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            _groundOverlaps++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            _groundOverlaps--;
        }
    }

    private void OnValidate()
    {
        var boxCollider = GetComponent<BoxCollider2D>();

        if (!boxCollider.isTrigger)
        {
            Debug.LogWarning("GroundCheck collider must be a trigger.", boxCollider);
        }
    }
}
