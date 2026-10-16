using System;
using __SARV.Common.Base;
using __SARV.Framework.Module.Interactor.Event;
using UnityEngine;

namespace __SARV.Framework.Module.Interactor.SubInteractor
{
    public abstract class SVSubInteractorEvent : SVOverrideMonoBehaviour
    {
        [HideInInspector] public SVOnInteractionAvailabilityEventHandler OnInteractionAvailabilityChanged;
    }
}