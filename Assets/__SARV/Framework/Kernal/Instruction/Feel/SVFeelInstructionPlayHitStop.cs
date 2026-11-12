using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Module.Feel;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction
{
    [SVTitle("PlayHitStop")]
    [SVCategory(SVConstantCategory.Instruction.FEEL)]
    [SVDescription("Briefly pauses the game to emphasize an impact, making attacks and collisions feel more impactful")]
    [Serializable]
    public class SVFeelInstructionPlayHitStop : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        private SARVIdentifier identifier;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Play Hit Stop {(identifier == null ? "..." : identifier.SkipWords(2))}";
        
        protected override Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            SARVFeel.Instance.PlayHitStop(identifier);
            return SVInstructionResult.DEFAULT_RESULT;
        }
    }
}