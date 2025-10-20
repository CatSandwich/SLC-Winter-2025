using UnityEngine;
using UnityEngine.Events;

public class PossessionTarget : MonoBehaviour
{
    public GameObject[] EnableWhilePossessedObjects;
    public MonoBehaviour[] EnableWhilePossessedComponents;
    public UnityEvent PossessionStarted;
    public UnityEvent PossessionEnded;

    private void Start()
    {
        PossessionStarted.AddListener(() => SetWhilePossessedStates(true));
        PossessionEnded.AddListener(() => SetWhilePossessedStates(false));

        PossessionEnded.Invoke();
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
