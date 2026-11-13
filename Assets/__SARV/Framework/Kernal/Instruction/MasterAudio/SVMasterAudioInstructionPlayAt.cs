using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Kernal.Property;
using __SARV.Framework.Module.Identifier;
using __SARV.SceneControl.Game;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction
{
    [SVTitle("PlayAt")]
    [SVCategory(SVConstantCategory.Instruction.MASTER_AUDIO)]
    [SVDescription("Plays a sound at the specified world position")]
    [Serializable]
    public class SVMasterAudioInstructionPlayAt : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        private SARVIdentifier identifier;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<Vector3> position = new SVVector3Property();

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Play {(identifier == null ? "..." : identifier.SkipWords(2))} sound at {position}";

        protected override Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            var pos = position.GetValue(argument);
            SARVGame.Instance.PlaySoundAt(identifier, pos);
            return SVInstructionResult.DEFAULT_RESULT;
        }
    }
}