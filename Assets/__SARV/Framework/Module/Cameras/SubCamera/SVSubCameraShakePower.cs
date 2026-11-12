using System.Collections.Generic;
using __SARV.Framework.Module.Cameras.Entity;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Cameras.SubCamera
{
    public abstract class SVSubCameraShakePower : SVSubCameraShot
    {
        [FoldoutGroup("HitStop")] [SerializeField] [RequiredListLength(1, 10)]
        private List<SVShakePower> shakePowers = new();
        
        [FoldoutGroup("Shake")] [SerializeField]
        private float maxSafePositionOffset = 0.12f;

        [FoldoutGroup("Shake")] [SerializeField]
        private Vector3 maxSafeRotationOffset = new(4f, 4f, 2f);

        private bool _isShaking;
        private Vector3 _baseLocalPosition;
        private Quaternion _baseLocalRotation;
        private readonly SVActiveShakePower[] _activeShakePowers = new SVActiveShakePower[MAX_ACTIVE_SHAKE_POWERS];
        private readonly Dictionary<SARVIdentifier, SVShakePower> _runtimeHitStops = new();

        private const int MAX_ACTIVE_SHAKE_POWERS = 4;

        protected override void Awake()
        {
            base.Awake();
            HandleShakePowersToDictionary();
        }

        protected override void Start()
        {
            base.Start();
            _baseLocalPosition = CurrentCameraShot.ShakePivotTransform.localPosition;
            _baseLocalRotation = CurrentCameraShot.ShakePivotTransform.localRotation;
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            //HandleCameraShake();
        }
        
        public void Shake(SARVIdentifier identifier)
        {
            var shakePower = _runtimeHitStops[identifier];
            AddActiveShakePower(shakePower);
        }

        private void HandleCameraShake()
        {
            Vector3 finalPosition = Vector3.zero;
            Vector3 finalRotation = Vector3.zero;

            bool hasAnyShake = false;

            for (int i = 0; i < MAX_ACTIVE_SHAKE_POWERS; i++)
            {
                if (_activeShakePowers[i].ShakePower == null)
                {
                    continue;
                }

                hasAnyShake = true;

                var shake = _activeShakePowers[i];
                shake.Elapsed += Time.deltaTime;

                var t = shake.Elapsed / shake.ShakePower.Duration;

                // REMOVE finished shake
                if (t >= 1f)
                {
                    _activeShakePowers[i].ShakePower = null;
                    continue;
                }

                float fade = shake.ShakePower.FadeCurve.Evaluate(t);

                // automatic priority weighting
                float priorityWeight = Mathf.Lerp(0.25f, 1f, shake.ShakePower.Priority / 2f);

                float amplitude = shake.ShakePower.Strength * fade * priorityWeight;
                float time = shake.Elapsed * shake.ShakePower.Speed;

                Vector3 pos = new Vector3(
                    (Mathf.PerlinNoise(shake.Seed + 0f, time) - 0.5f) * 2f * shake.ShakePower.PositionAmplitude.x,
                    (Mathf.PerlinNoise(shake.Seed + 1f, time) - 0.5f) * 2f * shake.ShakePower.PositionAmplitude.y,
                    (Mathf.PerlinNoise(shake.Seed + 2f, time) - 0.5f) * 2f * shake.ShakePower.PositionAmplitude.z
                );

                Vector3 rot = new Vector3(
                    (Mathf.PerlinNoise(shake.Seed + 3f, time) - 0.5f) * 2f * shake.ShakePower.RotationAmplitude.x,
                    (Mathf.PerlinNoise(shake.Seed + 4f, time) - 0.5f) * 2f * shake.ShakePower.RotationAmplitude.y,
                    (Mathf.PerlinNoise(shake.Seed + 5f, time) - 0.5f) * 2f * shake.ShakePower.RotationAmplitude.z
                );

                finalPosition += pos * amplitude;
                finalRotation += rot * amplitude;

                _activeShakePowers[i] = shake;
            }

            if (!hasAnyShake)
            {
                return;
            }

            finalPosition = Vector3.ClampMagnitude(finalPosition, maxSafePositionOffset);

            finalRotation.x = Mathf.Clamp(finalRotation.x, -maxSafeRotationOffset.x, maxSafeRotationOffset.x);
            finalRotation.y = Mathf.Clamp(finalRotation.y, -maxSafeRotationOffset.y, maxSafeRotationOffset.y);
            finalRotation.z = Mathf.Clamp(finalRotation.z, -maxSafeRotationOffset.z, maxSafeRotationOffset.z);

            CurrentCameraShot.ShakePivotTransform.localPosition = _baseLocalPosition + finalPosition;
            CurrentCameraShot.ShakePivotTransform.localRotation = _baseLocalRotation * Quaternion.Euler(finalRotation);
        }

        private void HandleShakePowersToDictionary()
        {
            foreach (var shakePower in shakePowers)
            {
                _runtimeHitStops.Add(shakePower.Identifier, shakePower);
            }
        }

        private void AddActiveShakePower(SVShakePower shakePower)
        {
            // 1. find empty slot
            for (int i = 0; i < MAX_ACTIVE_SHAKE_POWERS; i++)
            {
                if (_activeShakePowers[i].ShakePower == null)
                {
                    _activeShakePowers[i] = SVActiveShakePower.Create(shakePower);
                    return;
                }
            }

            // 2. replace weakest (priority-based)
            var weakest = 0;

            for (int i = 1; i < MAX_ACTIVE_SHAKE_POWERS; i++)
            {
                if (_activeShakePowers[i].ShakePower.Priority < _activeShakePowers[weakest].ShakePower.Priority)
                    weakest = i;
            }

            if (shakePower.Priority >= _activeShakePowers[weakest].ShakePower.Priority)
            {
                _activeShakePowers[weakest] = SVActiveShakePower.Create(shakePower);
            }
        }
    }
}