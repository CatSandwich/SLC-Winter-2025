using System.Collections.Generic;
using UnityEngine;

public class PossessionStack : MonoBehaviour
{
    public Stack<Possessable> Stack { get; } = new();

    public Possessable StartingEntity;
    public KeyCode UnpossessKey = KeyCode.Escape;

    public void Push(Possessable possessable)
    {
        if (Stack.TryPeek(out Possessable current))
        {
            current.PossessionEnded.Invoke();
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
        current.PossessionEnded.Invoke();
        Stack.Peek().PossessionStarted.Invoke();
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
