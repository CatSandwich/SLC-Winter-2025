using UnityEngine;

public class PossessionPedestal : MonoBehaviour
{
    public Possessable Target;

    public void OnInteract(Interactor interactor)
    {
        if (interactor.gameObject.TryGetComponent(out Possessable current))
        {
            Target.GetPossessedBy(current);
        }
    }
}
