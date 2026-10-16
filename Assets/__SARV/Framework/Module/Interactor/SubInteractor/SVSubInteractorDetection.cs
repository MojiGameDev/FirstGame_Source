using __SARV.Common.Extension;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Interactor.SubInteractor
{
    public abstract class SVSubInteractorDetection : SVSubInteractorSetting
    {
        [FoldoutGroup("Detection")] [SerializeField] [ReadOnly]
        protected bool isTargetDetected;

        protected GameObject Target;
        
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            if (other.IsLayerDetected(TargetLayer))
            {
                Target = other.gameObject;
                isTargetDetected = true;
            }
        }

        protected override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);
            if (other.IsLayerDetected(TargetLayer))
            {
                Target = null;
                isTargetDetected = false;
            }
        }
    }
}