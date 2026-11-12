using System;
using __SARV.Common.Base;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Cameras.Entity
{
    [Serializable]
    public class SVHitStop : SVSerializable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [Required]
        private SARVIdentifier identifier;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [PropertyRange(0f, 3f)]
        private float strength = 1f;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [PropertyRange(1f, 50f)]
        private float speed = 25f;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [PropertyRange(0.1f, 3f)]
        private float duration = 0.2f;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [PropertyRange(0, 10)]
        private int priority = 0;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private Vector3 positionAmplitude = new(0.05f, 0.05f, 0f);

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private Vector3 rotationAmplitude = new(2f, 2f, 0.5f);

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField]
        private AnimationCurve fadeCurve = AnimationCurve.EaseInOut(0, 1, 1, 0);

        private string GroupTitle => $"A shake with strength of {strength} in {duration} seconds";

        public SARVIdentifier Identifier => identifier;
        public float Strength => strength;
        public float Speed => speed;
        public float Duration => duration;
        public Vector3 PositionAmplitude => positionAmplitude;
        public Vector3 RotationAmplitude => rotationAmplitude;
        public int Priority => priority;
        public AnimationCurve FadeCurve => fadeCurve;
    }
}