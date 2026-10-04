using __SARV.Core.Base;
using __SARV.Core.Extension;
using __SARV.Framework;
using UnityEditor;
using UnityEngine;

namespace __SARV.Editor
{
    public static class SVComponentCreatorEditor
    {
        [MenuItem("GameObject/SARV/Create Trigger", false, 10)]
        private static void CreateSARVTrigger(MenuCommand command)
        {
            CreateComponent<SARVTrigger>(command, "Trigger");
        }

        [MenuItem("GameObject/SARV/Create Action", false, 10)]
        private static void CreateSARVAction(MenuCommand command)
        {
            CreateComponent<SARVAction>(command, "Action");
        }

        [MenuItem("GameObject/SARV/Create Condition", false, 10)]
        private static void CreateSARVCondition(MenuCommand command)
        {
            CreateComponent<SARVCondition>(command, "Condition");
        }

        [MenuItem("CONTEXT/SARV/Create Trigger", true)]
        private static bool ValidateCreateSARVTrigger(MenuCommand command)
        {
            return command.context is GameObject;
        }

        [MenuItem("CONTEXT/SARV/Create Action", true)]
        private static bool ValidateCreateSARVAction(MenuCommand command)
        {
            return command.context is GameObject;
        }

        [MenuItem("CONTEXT/SARV/Create Condition", true)]
        private static bool ValidateCreateSARVCondition(MenuCommand command)
        {
            return command.context is GameObject;
        }

        private static void CreateComponent<TComponent>(MenuCommand command, string component) where TComponent : SVMonoBehaviour
        {
            var selectedObject = command.context as GameObject;

            if (selectedObject == null)
            {
                return;
            }

            // Create child
            var child = new GameObject($"New {component}");
            child.transform.SetParent(selectedObject.transform);
            child.transform.Reset();

            // Add the same component to the child
            child.AddComponent<TComponent>();

            // Select the newly created child
            Selection.activeGameObject = child;

            Undo.RegisterCreatedObjectUndo(child, $"Create {component}");
        }
    }
}