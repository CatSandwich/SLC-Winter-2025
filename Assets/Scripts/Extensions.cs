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

        public static void SetStartLifetimeMultiplier(this ParticleSystem particleSystem, float multiplier)
        {
            ParticleSystem.MainModule main = particleSystem.main;
            main.startLifetimeMultiplier = multiplier;
        }
    }
}
