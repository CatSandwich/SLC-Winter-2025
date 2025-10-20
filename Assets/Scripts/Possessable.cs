using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering;

public class Possessable : MonoBehaviour
{
    public bool StartPossessed;
    public Camera PreviewCamera;
    public GameObject[] EnableWhilePossessedObjects;
    public MonoBehaviour[] EnableWhilePossessedComponents;
    public UnityEvent PossessionStarted;
    public UnityEvent PossessionEnded;
    public KeyCode UnpossessKey = KeyCode.Escape;

    public RenderTexture PreviewTexture { get; private set; }
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

    private void Awake()
    {
        if (PreviewCamera)
        {
            PreviewTexture = new RenderTexture(256, 256, 32, GraphicsFormat.R8G8B8A8_UNorm, 8);
            PreviewTexture.Create();
            PreviewCamera.targetTexture = PreviewTexture;
        }
    }

    private void OnDestroy()
    {
        if (PreviewCamera)
        {
            PreviewCamera.targetTexture.Release();
        }
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
