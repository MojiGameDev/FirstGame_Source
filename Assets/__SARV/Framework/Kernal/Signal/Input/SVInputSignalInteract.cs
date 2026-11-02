using System;
using __SARV.Common.Access;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Module.Actor.Access;
using __SARV.Framework.Module.Interactor;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal.Signal
{
    [SVTitle("Interact")]
    [SVCategory(SVConstantCategory.Signal.INPUT)]
    [SVDescription("Executes the trigger when the player presses the interact input while interaction is available")]
    [Serializable]
    public class SVInputSignalInteract : SVSignalComponent
    {
        [SerializeReference] [HideReferenceObjectPicker] [Required]
        private SARVInteractor interactor;

        public override void HandleUpdate(SARVTrigger trigger)
        {
            if (interactor.CanInteract && SVAccessPlayer.Instance.InputInteract)
            {
                trigger.Execute();
            }
        }
    }
}