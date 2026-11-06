using __SARV.Common.Utils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubHurtpoint
{
    public abstract class SVSubHitpointGizmos : SVSubHitpointSetting
    {
        [FoldoutGroup("Gizmos")] [SerializeField]
        private bool showGizmos = true;

        [FoldoutGroup("Gizmos")] [SerializeField]
        private bool gizmosOnSelect = true;

        [FoldoutGroup("Gizmos")] [SerializeField] [ColorPalette]
        private Color gizmoColor = Color.red;

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
            if (!showGizmos || colliderPoint == null)
            {
                return;
            }

            SVGizmosUtils.DrawCollider(colliderPoint, gizmoColor);
        }
    }
}