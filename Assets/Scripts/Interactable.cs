using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public GameObject[] EnabledWhileCanInteract;
    public UnityEvent<Interactor> Interacted;
}