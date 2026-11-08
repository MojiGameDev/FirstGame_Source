using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Instruction
{
    [SVTitle("Rotate")]
    [SVCategory(SVConstantCategory.Instruction.DO_TWEEN_PRO)]
    [SVDescription("Rotates a target GameObject to a specified angle in world or local space")]
    [Serializable]
    public class SVDOTweenProInstructionRotate : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<GameObject> target = new SVGameObjectProperty();

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private bool isWorldSpace = false;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVPropertyComponent<Vector3> toAngle = new SVVector3Property();

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private float delay = 0f;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private float duration = 2f;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private Ease ease = Ease.InExpo;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private bool waitToFinish = false;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")} Rotate {target} in {(isWorldSpace ? "world" : "local")} space to {toAngle}";

        protected override async Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            Tween tween;
            var targetGO = target.GetValue(argument);
            var targetToAngle = toAngle.GetValue(argument);
            if (isWorldSpace)
            {
                tween = targetGO.transform.DORotate(targetToAngle, duration)
                    .SetDelay(delay)
                    .SetEase(ease);
            }
            else
            {
                tween = targetGO.transform.DOLocalRotate(targetToAngle, duration)
                    .SetDelay(delay)
                    .SetEase(ease);
            }

            if (waitToFinish)
            {
                await tween.AsyncWaitForCompletion();
            }

            return await SVInstructionResult.DEFAULT_RESULT;
        }
    }
}