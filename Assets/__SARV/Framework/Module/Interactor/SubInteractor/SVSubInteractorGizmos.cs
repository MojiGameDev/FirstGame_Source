using __SARV.Common.Extension;
using __SARV.Common.Utils;
using Sirenix.OdinInspector;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace __SARV.Framework.Module.Interactor.SubInteractor
{
    public abstract class SVSubInteractorGizmos : SVSubInteractorManager
    {
        [FoldoutGroup("Gizmos")] [SerializeField]
        private bool showGizmos = true;

        [FoldoutGroup("Gizmos")] [SerializeField]
        private bool gizmosOnSelect = true;

        [FoldoutGroup("Gizmos")] [SerializeField] [PropertyRange(0.1f, 0.5)]
        private float gizmoArchPointRadius = 0.15f;

        [FoldoutGroup("Gizmos")] [SerializeField] [ColorPalette]
        private Color gizmoCircleColor = Color.blue;

        [FoldoutGroup("Gizmos")] [SerializeField] [ColorPalette]
        private Color gizmoArchColor = Color.cyan;

        [FoldoutGroup("Gizmos")] [SerializeField] [ColorPalette]
        private Color gizmoArchPointColor = Color.magenta;

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            if (!gizmosOnSelect)
            {
                HandleShowGizmos();
            }
        }

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            HandleShowGizmos();
        }

        private void HandleShowGizmos()
        {
            if (!showGizmos || interactionPoints == null)
            {
                return;
            }

            SVGizmosUtils.DrawCircle(transform, sphereCollider.center, interactionAvailabilityRange, gizmoCircleColor);

            foreach (var point in interactionPoints)
            {
                if (point == null)
                {
                    continue;
                }

                SVGizmosUtils.DrawArch(point, interactionAngle, gizmoArchPointRadius, gizmoArchPointColor, interactionRange, gizmoArchColor);
            }
        }
    }
}