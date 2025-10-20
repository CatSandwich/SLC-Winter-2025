using UnityEngine;
using UnityEngine.Events;

public class Possessable : MonoBehaviour
{
    public bool StartPossessed;
    public GameObject[] EnableWhilePossessedObjects;
    public MonoBehaviour[] EnableWhilePossessedComponents;
    public UnityEvent PossessionStarted;
    public UnityEvent PossessionEnded;
    public KeyCode UnpossessKey = KeyCode.Escape;

    private Possessable _possessedBy;

    public void GetPossessedBy(Possessable from)
    {
        _possessedBy = from;
        from.PossessionEnded.Invoke();
        PossessionStarted.Invoke();
    }

    private void Unpossess()
    {
        PossessionEnded.Invoke();
        _possessedBy.PossessionStarted.Invoke();
        _possessedBy = null;
    }

    private void Start()
    {
        PossessionStarted.AddListener(() => SetWhilePossessedStates(true));
        PossessionEnded.AddListener(() => SetWhilePossessedStates(false));

        if (StartPossessed)
        {
            PossessionStarted.Invoke();
        }
        else
        {
            PossessionEnded.Invoke();
        }
    }

    private void Update()
    {
        if (_possessedBy && Input.GetKeyDown(UnpossessKey))
        {
            Unpossess();
        }
    }

    private void SetWhilePossessedStates(bool isPossessed)
    {
        foreach (GameObject obj in EnableWhilePossessedObjects)
        {
            obj.SetActive(isPossessed);
        }

        foreach (MonoBehaviour mono in EnableWhilePossessedComponents)
        {
            mono.enabled = isPossessed;
        }
    }
}
