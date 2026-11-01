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
        protected SVActorSpeed movementSpeed = SVActorSpeed.NotMoving;

        protected List<GameObject> PropCache = new();

        public SARVInteractor CurrentInteractor { get; protected set; }
        public SARVMeleeWeapon CurrentMeleeWeapon { get; protected set; }
        public SARVMeleeShield CurrentMeleeShield { get; protected set; }
        public SVActorSpeed MovementSpeed => movementSpeed;

        public void SetMovementSpeed(SVActorSpeed speed)
        {
            movementSpeed = speed;
        }
    }
}