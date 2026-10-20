using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Common.Utils;
using __SARV.Framework.Integration.OdinInspector.Runtime;
using __SARV.Framework.Kernal.Property;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace __SARV.Framework.Kernal.Instruction
{
    [SVTitle("Destroy")]
    [SVCategory(SVConstantCategory.Instruction.GAME_OBJECT)]
    [SVDescription("Destroys a Game Object")]
    [Serializable]
    public class SVGameObjectInstructionDestroy : SVInstructionComponent
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideLabel] [HideReferenceObjectPicker] [SVRequired]
        private SVPropertyComponent<GameObject> target = new SVGameObjectProperty();

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [PropertyRange(0f, 10f)]
        private float delay = 1f;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private bool detachChildren;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [ShowIf(nameof(IsWaitToFinishMustShowed))]
        private bool waitToFinish;

        protected override string GroupTitle => $"{(Disabled ? "Disabled - " : "")}Destroy {target}";
        private bool IsWaitToFinishMustShowed => delay > 0f;

        protected override async Task<SVInstructionResult> ExecuteInternal(SVArgument argument)
        {
            var gameObject = target.GetValue(argument);
            if (delay <= 0)
            {
                Object.Destroy(gameObject);
            }
            else
            {
                Object.Destroy(gameObject, delay);
                if (waitToFinish)
                {
                    await SVTaskUtils.Wait(delay, false);
                }
            }

            if (detachChildren)
            {
                gameObject.transform.DetachChildren();
            }
            
            return await SVInstructionResult.DEFAULT_RESULT;
        }
    }
}