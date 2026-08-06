using UnityEngine;

namespace __MD.Script.Core.Extension
{
    public static class MDLayerMaskExtension
    {
        public static bool IsContains(this LayerMask source, int layer)
        {
            return (source & (1 << layer)) != 0;
        }

        public static bool IsNotContains(this LayerMask source, int layer)
        {
            return (source & (1 << layer)) == 0;
        }
        
        public static int GetLayerIndex(this LayerMask source)
        {
            return (int)Mathf.Log(source.value, 2);
        }
    }
}