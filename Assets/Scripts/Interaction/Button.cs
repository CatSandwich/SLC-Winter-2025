using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public GameObject[] EnableWhilePressed;
    public GameObject[] EnableWhileReleased;

    public UnityEvent Pressed;
    public UnityEvent Released;

    public int Overlaps
    {
        get => _overlaps;
        set
        {
            if (_overlaps == 0 && value == 1)
            {
                Press();
            }

            if (_overlaps == 1 && value == 0)
            {
                Release();
            }

            _overlaps = value;
        }
    }
    private int _overlaps;

    private void Press()
    {
        Pressed.Invoke();

        foreach (GameObject obj in EnableWhileReleased)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in EnableWhilePressed)
        {
            obj.SetActive(true);
        }
    }

    private void Release()
    {
        Released.Invoke();

        foreach (GameObject obj in EnableWhilePressed)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in EnableWhileReleased)
        {
            obj.SetActive(true);
        }
    }

    private void Start()
    {
        Release();
    }
}
