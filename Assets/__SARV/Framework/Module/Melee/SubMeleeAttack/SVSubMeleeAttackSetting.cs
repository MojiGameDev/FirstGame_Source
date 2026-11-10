using __SARV.Common.Base;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Module.Reaction.Enum;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeAttack
{
    public abstract class SVSubMeleeAttackSetting : SVScriptableObject
    {
        [BoxGroup("Setting")] [SerializeField] private StringAsset transitionAlias;

        [BoxGroup("Setting")] [SerializeField] [HideLabel]
        private SVBone bone = new(HumanBodyBones.RightHand);

        [BoxGroup("Setting")] [SerializeField] private SVReactionPower power = SVReactionPower.Light;

        [BoxGroup("Setting")] [PropertyRange(10f, 500f)] [SerializeField]
        private float force = 100f;

        public StringAsset TransitionAlias => transitionAlias;
        public SVBone Bone => bone;
        public SVReactionPower Power => power;
        public float Force => force;
    }
}