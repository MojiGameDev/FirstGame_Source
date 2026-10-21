using System;
using __SARV.Common.Utils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.SubFootstep
{
    [Serializable]
    public abstract class SVSubFootstepGizmos : SVSubFootstepManager
    {
        [BoxGroup("Gizmos")] [SerializeField] private bool showGizmos = true;

        [BoxGroup("Gizmos")] [SerializeField] private bool gizmosOnSelect = true;

        [BoxGroup("Gizmos")] [SerializeField] [ColorPalette]
        private Color gizmoCircleColor = Color.green;

        [BoxGroup("Gizmos")] [SerializeField] [PropertyRange(0.02f, 0.1f)]
        private float gizmosRadius = 0.05f;

        public override void HandleOnDrawGizmos()
        {
            base.HandleOnDrawGizmos();
            if (!gizmosOnSelect)
            {
                HandleShowGizmos();
            }
        }

        public override void HandleOnDrawGizmosSelected()
        {
            base.HandleOnDrawGizmosSelected();
            HandleShowGizmos();
        }

        private void HandleShowGizmos()
        {
            if (!showGizmos)
            {
                return;
            }

            foreach (var foot in feet)
            {
                if (foot == null || foot.FootTransform == null)
                {
                    continue;
                }
                SVGizmosUtils.DrawRaycastGuide(foot.FootTransform.position, gizmosRadius, raycastDistance, gizmoCircleColor);
            }
        }
    }
}