using System;
using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using __SARV.Framework.Module.Interactor;
using UnityEngine;

namespace __SARV.Framework.Common.Base
{
    public abstract class SVActor : SVOverrideMonoBehaviour
    {
        private SARVInteractor _lastInteractor;

        public SARVInteractor LastInteractor => _lastInteractor;

        public virtual void ChangeBehaviorTo(SARVIdentifier stateIdentifier)
        {
        }

        public void SetInteractor(SARVInteractor interactor)
        {
            _lastInteractor = interactor;
        }
    }
}