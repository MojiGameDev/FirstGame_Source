using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property;
using __SARV.Framework.Module.Actor;
using __SARV.Framework.Module.Interactor;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction
{
    [SVTitle("AttackProp")]
    [SVCategory(SVConstantCategory.Instruction.ACTOR)]
    [SVDescription("Attaches a prop to the Actor")]
    [Serializable]
    public class SVActorInstructionAttachProp : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<SARVActor> actor = new SVActorProperty();

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        private GameObject prop;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel]
        private SVBone bone = new(HumanBodyBones.RightHand);

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<Vector3> position = new SVVector3Property();

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<Vector3> rotation = new SVVector3Property();

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Attach {(prop == null ? "..." : prop.gameObject.name)} to the {bone} of {actor}";

        protected override Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            var act = actor.GetValue(argument);
            var pos = position.GetValue(argument);
            var rot = rotation.GetValue(argument);
            act.AttachProp(prop, bone, pos, rot);
            return SVInstructionResult.DEFAULT_RESULT;
        }
    }
}