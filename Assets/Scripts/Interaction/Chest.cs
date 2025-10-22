using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Splines;

public class Chest : MonoBehaviour
{
    public GameObject Open;
    public GameObject Closed;
    public GameObject Picture;
    public SplineContainer Spline;
    public float Duration;
    public Vector3 FinalScale;
    public SpriteRenderer DarkOverlay;
    public GameObject TextObject;
    public float TextSpeed;

    public Exit exit;

    private bool _isOpen;
    private TextMeshProUGUI _text;

    public void OnInteract()
    {
        if (_isOpen)
        {
            return;
        }

        _isOpen = true;

        Open.SetActive(true);
        Picture.SetActive(true);
        Closed.SetActive(false);

        StartCoroutine(FlyRoutine());
    }

    private void Start()
    {
        _text = TextObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    private IEnumerator FlyRoutine()
    {
        SoundManager.instance.PlaySFX(SoundManager.instance.audioClips[21], SoundManager.instance.musicSource, 1.0f);
        Vector3 startScale = Picture.transform.localScale;
        Picture.transform.position = Spline.EvaluatePosition(0f);
        float length = Spline.CalculateLength();
        DarkOverlay.enabled = true;

        float opacity = DarkOverlay.color.a;
        float start = Time.time;
        float end = start + Duration;
        DarkOverlay.color = new Color(0f, 0f, 0f, 0f);

        while (Time.time < end)
        {
            yield return null;
            float t = (Time.time - start) / (end - start);
            Picture.transform.position = Spline.EvaluatePosition(t * t * t);
            Picture.transform.localScale = Vector3.Lerp(startScale, FinalScale, t * t * t);
            DarkOverlay.color = new Color(0f, 0f, 0f, Mathf.Lerp(0f, opacity, t));
        }

        Picture.transform.position = Spline.EvaluatePosition(length);
        Picture.transform.localScale = FinalScale;
        Picture.GetComponent<ParticleSystem>().Play();
        DarkOverlay.color = new Color(0f, 0f, 0f, opacity);

        yield return new WaitForSeconds(2f);

        _text.maxVisibleCharacters = 0;
        TextObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        float chars = 0f;

        while (_text.maxVisibleCharacters < _text.text.Length)
        {
            yield return null;
            chars += TextSpeed * Time.deltaTime;
            _text.maxVisibleCharacters = (int)chars;
        }

        yield return new WaitForSeconds(5.0f);

        StartCoroutine(exit.Endgame());
    }
}