using System.Collections.Generic;
using System.Reflection;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif
using UnityEngine;

namespace __MD.Script.Core.Util
{
    public static class MDEditorUtility
    {
        public static void Save(Object obj, string undoName = "Modify")
        {
#if UNITY_EDITOR
            if (obj == null)
            {
                return;
            }

            var root = PrefabUtility.GetOutermostPrefabInstanceRoot(obj);
            
            if (root == null)
            {
                return;
            }
            
            Undo.RecordObject(root, undoName);

            EditorUtility.SetDirty(root);

            PrefabUtility.RecordPrefabInstancePropertyModifications(root);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
#endif
        }

        public static List<string> GetAllTags()
        {
#if UNITY_EDITOR
            return new List<string>(InternalEditorUtility.tags);
#else
return new List<string>();
#endif
        }

        public static List<string> GetAllLayers()
        {
#if UNITY_EDITOR
            return new List<string>(InternalEditorUtility.layers);
#else
return new List<string>();
#endif
        }

#if UNITY_EDITOR
        public static EditorWindow FindByTitle(string title)
        {
            var allWindows = Resources.FindObjectsOfTypeAll<EditorWindow>();

            foreach (var window in allWindows)
            {
                if (window == null) continue;

                // titleContent is the safe modern way
                GUIContent tc = window.titleContent;
                if (tc != null && tc.text == title)
                {
                    return window;
                }
            }

            return null;
        }
#endif

        public static void LockActiveInspector()
        {
#if UNITY_EDITOR
            var inspectorType = typeof(Editor).Assembly.GetType("UnityEditor.InspectorWindow");
            if (inspectorType == null)
            {
                Debug.LogError("InspectorWindow type not found!");
                return;
            }

            // Find all open Inspector windows
            var inspectors = (EditorWindow[])Resources.FindObjectsOfTypeAll(inspectorType);

            if (inspectors.Length == 0)
            {
                Debug.LogWarning("No Inspector windows found!");
                return;
            }

            // Find the active Inspector (the one with focus)
            EditorWindow activeInspector = null;

            foreach (EditorWindow inspector in inspectors)
            {
                if (inspector != null && inspector.hasFocus)
                {
                    activeInspector = inspector;
                    break;
                }
            }

            // If no focused Inspector, use the first one
            if (activeInspector == null && inspectors.Length > 0)
            {
                activeInspector = inspectors[0];
            }

            if (activeInspector == null)
            {
                Debug.LogWarning("No active Inspector found!");
                return;
            }

            // Lock the Inspector
            var isLockedProp = inspectorType.GetProperty("isLocked",
                BindingFlags.Public | BindingFlags.Instance);

            if (isLockedProp != null)
            {
                bool isCurrentlyLocked = (bool)isLockedProp.GetValue(activeInspector);
                isLockedProp.SetValue(activeInspector, true);

                activeInspector.Repaint();
            }
            else
            {
                Debug.LogError("Could not find isLocked property!");
            }
#endif
        }
    }
}