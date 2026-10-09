using __SARV.Framework;
using UnityEngine;

namespace __SARV.Core.Base
{
    public class SVAccess<TType> where TType : SARV
    {
        public static TType Instance { get; private set; }
        public static GameObject GameObject => Instance != null ? Instance.gameObject : null;
        public static Transform Transform => Instance != null ? Instance.transform : null;

        public static void Initial(TType sarv)
        {
            Instance = sarv;
        }
    }
}