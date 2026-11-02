using __SARV.Common.Base;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeAttack
{
    public abstract class SVSubMeleeAttackSetting : SVScriptableObject
    {
        [BoxGroup("Setting")] [SerializeField]
        private StringAsset transitionAlias;

        public StringAsset TransitionAlias => transitionAlias;
    }
}