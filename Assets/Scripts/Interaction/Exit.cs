using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string NextScene;

    public void OnInteract()
    {
        SceneManager.LoadScene(NextScene);
    }
}