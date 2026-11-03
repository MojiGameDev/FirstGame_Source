using System;
using __SARV.Framework.Module.Actor.Enum;
using __SARV.Framework.Module.Interactor;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    [Serializable]
    public abstract class SVSubActorData : SVSubActorInput
    {
        [FoldoutGroup("Data")] [SerializeField] [ReadOnly]
        protected SVActorSpeed currentSpeed = SVActorSpeed.NotMoving;
        
        public SVActorSpeed CurrentSpeed => currentSpeed;
        public SARVInteractor CurrentInteractor { get; protected set; }

        public void SetMovementSpeed(SVActorSpeed actorSpeed)
        {
            currentSpeed = actorSpeed;
        }
    }
}