using __SARV.Core.Extension;
using __SARV.Framework;
using UnityEditor;
using UnityEngine;

namespace __SARV.Editor
{
    public static class SVLogicCreatorEditor
    {
        [MenuItem("GameObject/SARV/Create Trigger", false, 10)]
        private static void CreateSARVTrigger(MenuCommand command)
        {
            var selectedObject = command.context as GameObject;

            if (selectedObject == null)
            {
                return;
            }
            
            // Create child
            var child = new GameObject("New Trigger");
            child.transform.SetParent(selectedObject.transform);
            child.transform.Reset();

            // Add the same component to the child
            child.AddComponent<SARVTrigger>();

            // Select the newly created child
            Selection.activeGameObject = child;

            Undo.RegisterCreatedObjectUndo(child, "Create Trigger");
        }

        // [MenuItem("CONTEXT/SARV/Create Trigger", true)]
        // private static bool ValidateCreateSARVTrigger(MenuCommand command)
        // {
        //     return command.context is GameObject;
        // }
    }
}