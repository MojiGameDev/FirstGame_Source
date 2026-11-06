using __SARV.Common.Base;
using __SARV.Framework.Common.Entity;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeAttack
{
    public abstract class SVSubMeleeAttackSetting : SVScriptableObject
    {
        [BoxGroup("Setting")] [SerializeField]
        private StringAsset transitionAlias;

        [BoxGroup("Setting")] [SerializeField] [HideLabel]
        private SVBone bone = new(HumanBodyBones.RightHand);

        public StringAsset TransitionAlias => transitionAlias;
        public SVBone Bone => bone;
    }
}