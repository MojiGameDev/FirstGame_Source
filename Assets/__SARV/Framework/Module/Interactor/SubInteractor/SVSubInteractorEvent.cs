using System;
using __SARV.Framework.Module.Interactor.Event;
using UnityEngine;

namespace __SARV.Framework.Module.Interactor.SubInteractor
{
    public abstract class SVSubInteractorEvent : SVSubInteractorReference
    {
        [HideInInspector] public SVOnInteractionAvailabilityEventHandler OnInteractionAvailabilityChanged;
    }
}