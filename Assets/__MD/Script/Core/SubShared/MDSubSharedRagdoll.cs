using System;
using System.Collections.Generic;
using System.Linq;
using __MD.Script.Core.Extension;
using __MD.Script.Core.SubShared.Base;
using __MD.Script.Core.Util;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace __MD.Script.Core.SubShared
{
    [Serializable]
    public class MDSubSharedRagdoll : MDSharedCharacter
    {
        [BoxGroup("Rigidbodies")] [SerializeField] [ReadOnly] [PropertyOrder(0)]
        private List<Rigidbody> rigidbodies = new();

        [BoxGroup("Setting")] [SerializeField] [PropertyOrder(1)]
        private LayerMask ragdollLayer;

        [Button(ButtonSizes.Medium, Icon = SdfIconType.CheckCircle)]
        [HorizontalGroup("Group01")]
        [PropertyOrder(0)]
        private void EnableRagdoll()
        {
            HandleEnableRagdoll();
        }

        [Button(ButtonSizes.Medium, Icon = SdfIconType.StopCircle)]
        [HorizontalGroup("Group01")]
        [PropertyOrder(0)]
        private void DisableRagdoll()
        {
            HandleDisableRagdoll();
        }

        [Button(ButtonSizes.Medium, Icon = SdfIconType.Recycle)]
        [HorizontalGroup("Group01")]
        [PropertyOrder(0)]
        private void RemoveRagdoll()
        {
#if UNITY_EDITOR
            rigidbodies = rigidbodies.Where(d => d != null).ToList();
            if (!rigidbodies.Any())
            {
                return;
            }

            var transform = rigidbodies.First().transform;
            foreach (var rigidbody in rigidbodies)
            {
                var jointComponent = rigidbody.GetComponent<Joint>();
                var colliderComponent = rigidbody.GetComponent<Collider>();
                Object.DestroyImmediate(colliderComponent);
                Object.DestroyImmediate(jointComponent);
                Object.DestroyImmediate(rigidbody);
            }

            rigidbodies.Clear();
            MDEditorUtility.Save(transform);
#endif
        }

        [Button(ButtonSizes.Medium, Icon = SdfIconType.StopCircle)]
        [HorizontalGroup("Group02")]
        [PropertyOrder(1)]
        private void ChangeRagdollLayer()
        {
#if UNITY_EDITOR
            foreach (var rigidbody in rigidbodies)
            {
                rigidbody.gameObject.layer = ragdollLayer.GetLayerIndex();
            }

            if (rigidbodies.Any())
            {
                MDEditorUtility.Save(rigidbodies.First().transform);
            }
#endif
        }

        public void SetupRigidbodies(List<Rigidbody> allRigidbodies)
        {
            rigidbodies.Clear();
            rigidbodies.AddRange(allRigidbodies);
        }

        public void HandleDisableRagdoll()
        {
            HandleRagdollState(true);
        }

        public void HandleEnableRagdoll()
        {
            HandleRagdollState(false);
        }

        private void HandleRagdollState(bool state)
        {
            foreach (var rigidbody in rigidbodies)
            {
                rigidbody.isKinematic = state;
            }
        }
    }
}