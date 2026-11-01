using System;
using System.Collections.Generic;
using __SARV.Actor.Common.Enum;
using __SARV.Framework.Module.Interactor;
using __SARV.Framework.Module.Melee;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubCharacter
{
    [Serializable]
    public abstract class SVSubActorData : SVSubActorReference
    {
        [FoldoutGroup("Data")] [SerializeField] [ReadOnly]
        protected SVCharacterMovementSpeed movementSpeed = SVCharacterMovementSpeed.NotMoving;

        protected List<GameObject> PropCache = new();

        public SARVInteractor CurrentInteractor { get; protected set; }
        public SARVMelee CurrentMelee { get; protected set; }
        public SVCharacterMovementSpeed MovementSpeed => movementSpeed;

        public void SetMovementSpeed(SVCharacterMovementSpeed speed)
        {
            movementSpeed = speed;
        }
    }
}