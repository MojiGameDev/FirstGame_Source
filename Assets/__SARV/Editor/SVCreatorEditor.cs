using __SARV.Core.Base;
using __SARV.Core.Extension;
using __SARV.Framework;
using __SARV.Indicator;
using __SARV.Variable;
using UnityEditor;
using UnityEngine;

namespace __SARV.Editor
{
    public static class SVCreatorEditor
    {
        [MenuItem("GameObject/SARV/Create Trigger", false, 10)]
        private static void CreateSARVTrigger(MenuCommand command)
        {
            CreateSARVGameObject<SARVTrigger>(command, "Trigger");
        }

        [MenuItem("GameObject/SARV/Create Action", false, 10)]
        private static void CreateSARVAction(MenuCommand command)
        {
            CreateSARVGameObject<SARVAction>(command, "Action");
        }

        [MenuItem("GameObject/SARV/Create Condition", false, 10)]
        private static void CreateSARVCondition(MenuCommand command)
        {
            CreateSARVGameObject<SARVCondition>(command, "Condition");
        }

        [MenuItem("GameObject/SARV/Create State Player", false, 10)]
        private static void CreateSARVStatePlayer(MenuCommand command)
        {
            CreateSARVGameObject<SARVStatePlayer>(command, "StatePlayer");
        }

        // [MenuItem("GameObject/SARV/Create State Agent", false, 10)]
        // private static void CreateSARVStateAgent(MenuCommand command)
        // {
        //     CreateSARVGameObject<SARVStateAgent>(command, "StateAgent");
        // }

        [MenuItem("GameObject/SARV/Create Scalar Variable", false, 10)]
        private static void CreateScalarVariable(MenuCommand command)
        {
            CreateSARVGameObject<SARVScalarVariable>(command, "ScalarVariable");
        }

        [MenuItem("GameObject/SARV/Create Indicator", false, 10)]
        private static void CreateIndicator(MenuCommand command)
        {
            CreateSARVGameObject<SARVIndicator>(command, "Indicator");
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

        [MenuItem("CONTEXT/SARV/Create State Player", true)]
        private static bool ValidateCreateSARVStatePlayer(MenuCommand command)
        {
            return command.context is GameObject;
        }

        // [MenuItem("CONTEXT/SARV/Create State Agent", true)]
        // private static bool ValidateCreateSARVStateAgent(MenuCommand command)
        // {
        //     return command.context is GameObject;
        // }

        [MenuItem("CONTEXT/SARV/Create Scalar Variable", true)]
        private static bool ValidateCreateScalarVariable(MenuCommand command)
        {
            return command.context is GameObject;
        }

        [MenuItem("CONTEXT/SARV/Create Indicator", true)]
        private static bool ValidateCreateIndicator(MenuCommand command)
        {
            return command.context is GameObject;
        }

        private static void CreateSARVGameObject<TComponent>(MenuCommand command, string component) where TComponent : SVMonoBehaviour
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