using System.Collections.Generic;
using System.Linq;
using __SARV.Framework.Common.Utils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Interactor.SubInteractor
{
    public abstract class SVSubInteractorPoint : SVSubInteractorSetting
    {
        [FoldoutGroup("Point")] [SerializeField] [Required] [RequiredListLength(1, 50)]
        protected List<Transform> interactionPoints = new();

        [FoldoutGroup("Point")] [SerializeField] [PropertyRange(0.5f, 5f)]
        private float radius = 2f;

        [FoldoutGroup("Point")] [SerializeField] [PropertyRange(0.1f, 2f)]
        private float distanceBetweenPoints = 1f;

        private GameObject PointContainer => GameObject.Find("InteractionPoint");
        private bool HasInteractionPoints => interactionPoints.Any();

        [FoldoutGroup("Point")]
        [HorizontalGroup("Point/Button01")]
        [Button]
        private void Generate()
        {
            if (distanceBetweenPoints <= 0f || radius <= 0f)
            {
                return;
            }

            // Remove previously generated points first.
            RemoveAll();

            var pointCount = Mathf.Max(
                1,
                Mathf.RoundToInt(2f * Mathf.PI * radius / distanceBetweenPoints)
            );

            var angleStep = 2f * Mathf.PI / pointCount;

            for (var i = 0; i < pointCount; i++)
            {
                var angle = i * angleStep;

                var position = new Vector3(
                    Mathf.Cos(angle) * radius,
                    0f,
                    Mathf.Sin(angle) * radius
                );

                var point = new GameObject($"Point_{i:00}");
                point.transform.parent = PointContainer.transform;
                point.transform.localPosition = position;
                point.transform.localRotation = Quaternion.LookRotation(-position);

                interactionPoints.Add(point.transform);
            }

#if UNITY_EDITOR
            SVEditorUtility.SavePrefabChanges(this);
#endif
        }

        [FoldoutGroup("Point")]
        [HorizontalGroup("Point/Button01")]
        [Button]
        [EnableIf(nameof(HasInteractionPoints))]
        private void RemoveAll()
        {
            for (var i = PointContainer.transform.childCount - 1; i >= 0; i--)
            {
                var child = PointContainer.transform.GetChild(i).gameObject;
#if UNITY_EDITOR
                DestroyImmediate(child);
#endif
            }

            interactionPoints.Clear();

#if UNITY_EDITOR
            SVEditorUtility.SavePrefabChanges(this);
#endif
        }

        [FoldoutGroup("Point")]
        [HorizontalGroup("Point/Button02")]
        [Button]
        [EnableIf(nameof(HasInteractionPoints))]
        protected void PlaceOnGround()
        {
            foreach (var point in interactionPoints)
            {
                if (point == null)
                {
                    continue;
                }

                var origin = point.position + Vector3.up * 1000f;

                if (Physics.Raycast(
                        origin,
                        Vector3.down,
                        out var hit,
                        2000f,
                        Physics.DefaultRaycastLayers,
                        QueryTriggerInteraction.Ignore))
                {
                    point.position = hit.point;
                }
            }
        }

        [FoldoutGroup("Point")]
        [HorizontalGroup("Point/Button02")]
        [Button]
        protected void Refresh()
        {
            interactionPoints.Clear();
            for (var i = 0; i < PointContainer.transform.childCount; i++)
            {
                interactionPoints.Add(PointContainer.transform.GetChild(i));
            }
        }
    }
}