using __SARV.Common.Extension;
using __SARV.Framework.Common.Entity;
using __SARV.Framework.Module.Interactor;
using __SARV.Framework.Module.Melee;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubActor
{
    public abstract class SVSubActorCharacter : SVSubActorAgent
    {
        public void SetInteractor(SARVInteractor interactor)
        {
            CurrentInteractor = interactor;
        }
    }
}