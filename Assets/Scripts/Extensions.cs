using UnityEngine;

namespace Assets.Scripts
{
    public static class Extensions
    {
        public static bool TryGetComponentInChildren<T>(this GameObject go, out T component)
            where T : MonoBehaviour
        {
            component = go.GetComponentInChildren<T>();
            return component;
        }
    }
}
