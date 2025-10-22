using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Exit : MonoBehaviour
{
    public string NextScene;
    public GameObject entranceDoor;
    public Transform circleFade;
    public Animator circleAnim;

    public void OnInteract()
    {
        if (!circleAnim.GetBool("isLevelFinished"))
        {
            SoundManager.instance.PlaySFX(SoundManager.instance.audioClips[19], SoundManager.instance.musicSource, 1.0f);

            Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
            circleFade.position = screenPoint;
            circleAnim.SetBool("isLevelFinished", true);
            circleAnim.Play("CircleFade_Close");
            StartCoroutine(GoToNextScene());
        }
    }

    IEnumerator GoToNextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(NextScene);
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator Endgame()
    {
        Vector3 screenPoint = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        circleFade.position = screenPoint;
        circleAnim.SetBool("isLevelFinished", true);
        circleAnim.Play("CircleFade_Close");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Credits");
    }

    void Start()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(entranceDoor.transform.position);
        circleFade.position = screenPoint;
        circleAnim.SetBool("isLevelFinished", false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !circleAnim.GetBool("isLevelFinished"))
        {
            if (SceneManager.GetActiveScene().name == "Level 11 Heist's Finale")
            {
                return;
            }
            SoundManager.instance.PlaySFX(SoundManager.instance.audioClips[17], SoundManager.instance.sfxSource, 1.0f);

            Vector3 screenPoint = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
            circleFade.position = screenPoint;
            circleAnim.SetBool("isLevelFinished", true);
            circleAnim.Play("CircleFade_Close");
            StartCoroutine(RestartScene());
        }
    }
}