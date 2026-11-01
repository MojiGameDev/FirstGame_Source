using UnityEngine;

namespace __SARV.Common.Base
{
    public class SVAccess<TType> where TType : SVMonoBehaviour
    {
        public static TType Instance { get; private set; }
        public static GameObject GameObject => Instance != null ? Instance.gameObject : null;
        public static Transform Transform => Instance != null ? Instance.transform : null;

        public static void Initial(TType actor)
        {
            Instance = actor;
        }
    }
}