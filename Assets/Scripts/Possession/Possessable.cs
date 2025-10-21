using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering;

public class Possessable : MonoBehaviour
{
    // Camera rendering a preview of this object.
    public Camera PreviewCamera;
    // Objects to enable only while this object is possessed.
    public GameObject[] EnableWhilePossessedObjects;
    // Components to enable only while this object is possessed.
    public MonoBehaviour[] EnableWhilePossessedComponents;
    // Raised when this object is possessed.
    public UnityEvent PossessionStarted;
    // Raised when this object is no longer possessed.
    public UnityEvent PossessionEnded;

    public RenderTexture PreviewTexture { get; private set; }
    public CreatureAnim possessedAnim;

    private void Awake()
    {
        if (PreviewCamera)
        {
            PreviewTexture = new RenderTexture(256, 256, 32, GraphicsFormat.R8G8B8A8_UNorm, 8);
            PreviewTexture.Create();
            PreviewCamera.targetTexture = PreviewTexture;
        }

        PossessionStarted.AddListener(() => SetWhilePossessedStates(true));
        PossessionEnded.AddListener(() => SetWhilePossessedStates(false));
        PossessionEnded.Invoke();
    }

    private void OnDestroy()
    {
        if (PreviewCamera)
        {
            PreviewCamera.targetTexture.Release();
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

        possessedAnim.BecomePossessed(isPossessed);
    }
}
