using UnityEngine;

public class PossessionPedestal : MonoBehaviour
{
    public static Material Material => Instantiate(_material ??= new Material(Shader.Find("Sprites/Default")));
    private static Material _material;

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
            Preview.material = Material;
            Preview.material.mainTexture = Target.PreviewCamera.targetTexture;
            Preview.material.color = new Color(1, 1, 1, .7f);
        }

        _stack = FindAnyObjectByType<PossessionStack>();
    }
}
