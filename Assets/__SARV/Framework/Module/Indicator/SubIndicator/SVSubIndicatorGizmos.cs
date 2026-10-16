#if UNITY_EDITOR
using UnityEditor;
#endif
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Indicator.SubIndicator
{
    public abstract class SVSubIndicatorGizmos : SVSubIndicatorManager
    {
        [FoldoutGroup("Gizmos")] [SerializeField]
        private bool showGizmos = true;

        [FoldoutGroup("Gizmos")] [SerializeField]
        private bool gizmosOnSelect = true;

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
            if (!showGizmos || sphereCollider == null)
            {
                return;
            }

            var center = transform.TransformPoint(sphereCollider.center);
            var radius = sphereCollider.radius * Mathf.Max(
                transform.lossyScale.x,
                transform.lossyScale.y,
                transform.lossyScale.z
            );

#if UNITY_EDITOR
            Handles.color = new Color(0f, 1f, 0f, 0.2f);
            Handles.DrawSolidDisc(center, Vector3.up, radius);

            Handles.color = Color.green;
            Handles.DrawWireDisc(center, Vector3.up, radius);
#endif
        }
    }
}