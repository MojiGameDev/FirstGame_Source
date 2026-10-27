using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEngine;

namespace __SARV.Misc.Editor
{
    public static class SVSceneViewCommand
    {
        [Shortcut("Scene View/Toggle UMotionCenterPoint", KeyCode.R, ShortcutModifiers.Shift)]
        private static void ToggleUMotionCenterPoint()
        {
            foreach (GameObject go in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (go.name != "UMotionCenterPoint" ||
                    EditorUtility.IsPersistent(go) ||
                    !go.scene.IsValid() ||
                    !go.scene.isLoaded)
                    continue;

                Undo.RecordObject(go, "Toggle MyObject");
                go.SetActive(!go.activeSelf);
                EditorUtility.SetDirty(go);
                return;
            }
        }
    }
}