#if UNITY_EDITOR
using UnityEditor;

namespace __SARV.Framework.Common.Utils
{
    public static class SVEditorUtility
    {
        public static void SavePrefabChanges(UnityEngine.Component component)
        {
            EditorUtility.SetDirty(component);

            if (PrefabUtility.IsPartOfPrefabInstance(component.gameObject))
            {
                PrefabUtility.RecordPrefabInstancePropertyModifications(component);
            }
        }
    }
}
#endif