using System.Collections.Generic;
using __SARV.Common.Utils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Actor.SubHitbox
{
    public abstract class SVSubHitboxGizmos : SVSubHitboxDetection
    {
        [FoldoutGroup("Gizmos")] [SerializeField]
        private bool showGizmos = true;

        [FoldoutGroup("Gizmos")] [SerializeField]
        private bool gizmosOnSelect = true;

        [FoldoutGroup("Gizmos")] [SerializeField] [ColorPalette]
        private Color normalGizmoColor = Color.yellow;

        [FoldoutGroup("Gizmos")] [SerializeField] [ColorPalette]
        private Color activeGizmoColor = Color.red;

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
            if (!showGizmos)
            {
                return;
            }

            SVGizmosUtils.DrawCube(GetWorldCenter(), transform.rotation, hitboxSize, IsActive ? activeGizmoColor : normalGizmoColor);
        }
    }
}