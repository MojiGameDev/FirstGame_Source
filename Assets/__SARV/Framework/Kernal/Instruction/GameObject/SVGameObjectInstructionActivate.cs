using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction
{
    [SVTitle("Activate")]
    [SVCategory(SVConstantCategory.Instruction.GAME_OBJECT)]
    [SVDescription("Activates/deactivates a Game Object")]
    [Serializable]
    public class SVGameObjectInstructionActivate : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<GameObject> target = new SVGameObjectProperty();

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private bool activate;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}{(activate ? "Activate" : "Deactivate")} {target}";

        protected override Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            var gameObject = target.GetValue(argument);
            gameObject.SetActive(activate);
            return SVInstructionResult.DEFAULT_RESULT;
        }
    }
}