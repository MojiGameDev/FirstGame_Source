using System.Collections.Generic;
using __SARV.Common.Base;
using __SARV.Framework.Module.Feel.Entity;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Feel.SubFell
{
    public abstract class SVSubFeelHitStop : SVSingletonLocalMonoBehaviour<SARVFeel>
    {
        [FoldoutGroup("HitStop")] [SerializeField] [RequiredListLength(1, 10)]
        private List<SVHitStop> hitStops = new();
        
        private readonly Dictionary<SARVIdentifier,SVHitStop> _runtimeHitPoints = new();
        
        private float _remainingTime;
        private float _originalTimeScale;
        private float _originalFixedDeltaTime;
        private float _currentHitStopScale = 1f;
        private bool _isActive;

        protected override void Awake()
        {
            base.Awake();
            HandleHitPointsToDictionary();
        }

        protected override void Update()
        {
            base.Update();
            
            Debug.Log(
                $"HitStop Active: {_isActive} | " +
                $"TimeScale: {Time.timeScale} | " +
                $"UnscaledDelta: {Time.unscaledDeltaTime} | " +
                $"Remaining: {_remainingTime}"
            );
            
            if (!_isActive)
            {
                return;
            }

            _remainingTime -= Time.unscaledDeltaTime;
            if (_remainingTime <= 0f)
            {
                StopHitStop();
            }
        }

        public void PlayHitStop(SARVIdentifier identifier)
        {
            var hitPoint = _runtimeHitPoints[identifier];

            if (!_isActive)
            {
                // Don't override an existing game pause.
                if (Time.timeScale <= 0f)
                {
                    return;
                }

                _originalTimeScale = Time.timeScale;
                _originalFixedDeltaTime = Time.fixedDeltaTime;
                _isActive = true;
            }

            // Always override the previous Hit Stop.
            _currentHitStopScale = hitPoint.TimeScale;
            _remainingTime = hitPoint.Duration;

            ApplyTimeScale();
        }
        
        public void StopHitStop()
        {
            if (!_isActive)
            {
                return;
            }

            Time.timeScale = _originalTimeScale;
            Time.fixedDeltaTime = _originalFixedDeltaTime;

            _remainingTime = 0f;
            _currentHitStopScale = 1f;
            _isActive = false;
        }

        private void ApplyTimeScale()
        {
            Time.timeScale = _originalTimeScale * _currentHitStopScale;
            Time.fixedDeltaTime = _originalFixedDeltaTime * _currentHitStopScale;
        }

        private void HandleHitPointsToDictionary()
        {
            foreach (var hitStop in hitStops)
            {
                _runtimeHitPoints.Add(hitStop.Identifier, hitStop);
            }
        }
    }
}