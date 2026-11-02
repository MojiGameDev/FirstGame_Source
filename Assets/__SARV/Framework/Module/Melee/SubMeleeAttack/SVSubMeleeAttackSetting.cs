using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeAttack
{
    public abstract class SVSubMeleeAttackSetting : SVScriptableObject
    {
        [BoxGroup("Setting")] [SerializeField] [HideLabel]
        private SARVIdentifier identifier;

        public SARVIdentifier Identifier => identifier;
    }
}