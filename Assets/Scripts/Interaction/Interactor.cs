using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public bool CanPressButton;

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
