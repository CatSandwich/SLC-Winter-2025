using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    public bool IsOn;
    public UnityEvent TurnedOn;
    public UnityEvent TurnedOff;
    public Animator leverAnim;

    public void Toggle()
    {
        IsOn = !IsOn;

        if (IsOn)
        {
            TurnedOn.Invoke();
            leverAnim.SetBool("isOn", true);
        }
        else
        {
            TurnedOff.Invoke();
            leverAnim.SetBool("isOn", false);
        }
    }
}
