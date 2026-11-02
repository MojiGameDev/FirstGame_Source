using System;
using System.Collections.Generic;
using __SARV.Framework.Module.Actor.Enum;
using __SARV.Framework.Module.Interactor;
using __SARV.Framework.Module.Melee;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    [Serializable]
    public abstract class SVSubActorData : SVSubActorInput
    {
        [FoldoutGroup("Data")] [SerializeField] [ReadOnly]
        protected SVActorSpeed currentSpeed = SVActorSpeed.NotMoving;

        [FoldoutGroup("Data")] [SerializeField] [ReadOnly]
        protected SVCombatType currentCombatType = SVCombatType.None;

        protected List<GameObject> PropCache = new();

        public SARVInteractor CurrentInteractor { get; protected set; }
        public SARVMeleeAttack CurrentMeleeAttack { get; protected set; }
        public SARVMeleeWeapon CurrentMeleeWeapon { get; protected set; }
        public SARVMeleeShield CurrentMeleeShield { get; protected set; }
        public SVActorSpeed CurrentSpeed => currentSpeed;
        public SVCombatType CurrentCombatType => currentCombatType;

        public void SetMovementSpeed(SVActorSpeed actorSpeed)
        {
            currentSpeed = actorSpeed;
        }

        public void SetCombatType(SVCombatType combatType)
        {
            currentCombatType = combatType;
        }
    }
}