using System;
using __SARV.Framework.Integration.Animancer.Enum;
using UnityEngine;

namespace __SARV.Framework.Integration.Animancer.Parameter.Type
{
    [Serializable]
    public struct SVMeleeAttackParameterType
    {
        [SerializeField] private SVMeleeAttackPhase attackPhase;

        public SVMeleeAttackPhase AttackPhase => attackPhase;
    }
}