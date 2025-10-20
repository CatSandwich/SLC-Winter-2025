using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    public bool IsOn;
    public UnityEvent TurnedOn;
    public UnityEvent TurnedOff;

    public void Toggle()
    {
        IsOn = !IsOn;
    }
}
