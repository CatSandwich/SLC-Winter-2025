using UnityEngine;

public class PossessionPedestal : MonoBehaviour
{
    public Possessable Target;
    public MeshRenderer Preview;

    private PossessionStack _stack;

    public void OnInteract(Interactor interactor)
    {
        _stack.Push(Target);
    }

    private void Start()
    {
        if (Target.PreviewCamera)
        {
            Preview.material = Instantiate(Preview.material);
            Preview.material.mainTexture = Target.PreviewCamera.targetTexture;
        }

        _stack = FindAnyObjectByType<PossessionStack>();
    }
}
