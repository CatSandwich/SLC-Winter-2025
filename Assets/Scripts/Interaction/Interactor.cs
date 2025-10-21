using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public bool CanPressButton;
    public bool CanBreakWalls;

    private List<Interactable> Overlapping { get; } = new();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Overlapping.FirstOrDefault()?.Interacted.Invoke(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponentInChildren(out Interactable interactable))
        {
            Overlapping.Add(interactable);
        }

        if (CanPressButton && other.gameObject.TryGetComponentInChildren(out Button button))
        {
            button.Overlaps++;
        }

        if (CanBreakWalls && other.gameObject.TryGetComponentInChildren(out BreakableWall breakableWall))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CanBreakWalls && collision.gameObject.TryGetComponentInChildren(out BreakableWall breakableWall))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponentInChildren(out Interactable interactable))
        {
            Overlapping.Remove(interactable);
        }

        if (CanPressButton && other.gameObject.TryGetComponentInChildren(out Button button))
        {
            button.Overlaps--;
        }
    }
}
