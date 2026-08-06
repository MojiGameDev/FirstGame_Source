using System;
using __MD.Script.Core.Base;
using __MD.Script.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __MD.Script.Cameras.Entity
{
    [Serializable]
    public class MDShakePower : MDSerializable
    {
        [FoldoutGroup("$CameraShakeTitle")] [SerializeField] [Required]
        private MDIdentifier identifier;

        [FoldoutGroup("$CameraShakeTitle")] [SerializeField] [PropertyRange(0f, 3f)]
        private float strength = 1f;

        [FoldoutGroup("$CameraShakeTitle")] [SerializeField] [PropertyRange(1f, 50f)]
        private float speed = 25f;

        [FoldoutGroup("$CameraShakeTitle")] [SerializeField] [PropertyRange(0.1f, 3f)]
        private float duration = 0.2f;

        [FoldoutGroup("$CameraShakeTitle")] [SerializeField] [PropertyRange(0, 10)]
        private int priority = 0;

        [FoldoutGroup("$CameraShakeTitle")] [SerializeField]
        private Vector3 positionAmplitude = new(0.05f, 0.05f, 0f);

        [FoldoutGroup("$CameraShakeTitle")] [SerializeField]
        private Vector3 rotationAmplitude = new(2f, 2f, 0.5f);

        [FoldoutGroup("$CameraShakeTitle")] [SerializeField]
        private AnimationCurve fadeCurve = AnimationCurve.EaseInOut(0, 1, 1, 0);

        private string CameraShakeTitle => $"A shake with strength of {strength} in {duration} seconds";

        public MDIdentifier Identifier => identifier;
        public float Strength => strength;
        public float Speed => speed;
        public float Duration => duration;
        public Vector3 PositionAmplitude => positionAmplitude;
        public Vector3 RotationAmplitude => rotationAmplitude;
        public int Priority => priority;
        public AnimationCurve FadeCurve => fadeCurve;

        public void ClearIdentifier()
        {
            identifier = null;
        }
    }
}