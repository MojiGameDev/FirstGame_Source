using __SARV.Common.Utils;
using Sirenix.OdinInspector;
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
        private Color gizmoArchCurrentColor = Color.red;

        [FoldoutGroup("Gizmos")] [SerializeField] [ColorPalette]
        private Color gizmoArchPointColor = Color.magenta;

        [FoldoutGroup("Gizmos")] [SerializeField] [ColorPalette]
        private Color gizmoArchCurrentPointColor = Color.yellow;

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

                var pointColor = _closestPoint != null && isTargetDetected && point == _closestPoint ? gizmoArchCurrentPointColor : gizmoArchPointColor;
                var archColor = _closestPoint != null && isTargetDetected && point == _closestPoint ? gizmoArchCurrentColor : gizmoArchColor;
                SVGizmosUtils.DrawArch(point, interactionAngle, gizmoArchPointRadius, pointColor, interactionRange, archColor);
            }
        }
    }
}