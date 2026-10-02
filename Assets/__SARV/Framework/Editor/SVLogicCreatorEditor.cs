using __SARV.Core.Extension;
using UnityEditor;
using UnityEngine;

namespace __SARV.Framework.Editor
{
    public static class SVLogicCreatorEditor
    {
        [MenuItem("SARV/Create Trigger", false, 10)]
        private static void CreateSARVTrigger(MenuCommand command)
        {
            var selectedObject = command.context as GameObject;

            if (selectedObject == null)
            {
                return;
            }

            // Add your custom component to the selected GameObject
            var component = selectedObject.AddComponent<SARVTrigger>();

            // Create child
            var child = new GameObject("Trigger");
            child.transform.SetParent(selectedObject.transform);
            child.transform.Reset();

            // Add the same component to the child
            child.AddComponent<SARVTrigger>();

            // Select the newly created child
            Selection.activeGameObject = child;

            Undo.RegisterCreatedObjectUndo(child, "Create Trigger");
            Undo.RegisterCreatedObjectUndo(component, "Add Trigger");
        }

        [MenuItem("SARV/Create Trigger", true)]
        private static bool ValidateCreateSARVTrigger(MenuCommand command)
        {
            return command.context is GameObject;
        }
    }
}