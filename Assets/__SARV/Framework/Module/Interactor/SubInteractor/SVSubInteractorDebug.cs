using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Interactor.SubInteractor
{
    public abstract class SVSubInteractorDebug : SVSubInteractorSetting
    {
        [FoldoutGroup("Debug")] [SerializeField]
        private bool showGizmos = true;

        [FoldoutGroup("Debug")] [SerializeField] [PropertyRange(0.1f, 0.5)]
        private float gizmoRadius = 0.15f;
    }
}