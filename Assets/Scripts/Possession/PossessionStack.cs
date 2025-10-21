using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class PossessionStack : MonoBehaviour
{
    public Stack<Possessable> Stack { get; } = new();

    public Possessable StartingEntity;
    public KeyCode UnpossessKey = KeyCode.Escape;
    public ParticleSystem ZapParticles;
    public float ZapLength;

    public void Push(Possessable possessable)
    {
        if (Stack.TryPeek(out Possessable current))
        {
            current.PossessionEnded.Invoke();
            StartCoroutine(Zap(current.transform.position, possessable.transform.position));
        }

        Stack.Push(possessable);
        possessable.PossessionStarted.Invoke();
    }

    public void Pop()
    {
        if (Stack.Count == 1)
        {
            return;
        }

        Possessable current = Stack.Pop();
        Possessable last = Stack.Peek();
        current.PossessionEnded.Invoke();
        last.PossessionStarted.Invoke();
        StartCoroutine(Zap(current.transform.position, last.transform.position));
    }

    private IEnumerator Zap(Vector3 from, Vector3 to)
    {
        ParticleSystem clone = Instantiate(ZapParticles, from, Quaternion.identity, transform);
        clone.gameObject.SetActive(true);

        float start = Time.time;
        float end = start + ZapLength;

        while (Time.time < end)
        {
            yield return null;
            float t = (Time.time - start) / ZapLength;
            clone.transform.position = Vector3.Lerp(from, to, t);
            clone.SetStartLifetimeMultiplier(Mathf.Lerp(0.9f, 1f, t));
        }

        clone.Stop();
        yield return new WaitForSeconds(clone.main.startLifetime.constant);
        Destroy(clone.gameObject);
    }

    private void Start()
    {
        Push(StartingEntity);
    }

    private void Update()
    {
        if (Input.GetKeyDown(UnpossessKey))
        {
            Pop();
        }
    }
}
