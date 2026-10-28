using __SARV.Common.Extension;
using __SARV.Framework.Common.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Interactor.SubInteractor
{
    public abstract class SVSubInteractorDetection : SVSubInteractorSetting
    {
        [FoldoutGroup("Detection")] [SerializeField] [ReadOnly]
        protected bool isTargetDetected;
        
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            if (other.gameObject == Actor.gameObject)
            {
                isTargetDetected = true;
            }
        }

        protected override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);
            if (other.gameObject == Actor.gameObject)
            {
                isTargetDetected = false;
            }
        }
    }
}