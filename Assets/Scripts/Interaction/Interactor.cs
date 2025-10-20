using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class Interactor : MonoBehaviour
{
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
            Debug.Log("Can interact: ", interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponentInChildren(out Interactable interactable))
        {
            Overlapping.Remove(interactable);
            Debug.Log("Can no longer interact: ", interactable);
        }
    }
}
