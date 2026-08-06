using __MD.Script.Core.Extension;
using UnityEngine;

namespace __MD.Script.Core.Utility
{
    /// <summary>
    /// Provides a simple, reusable cooldown mechanism for controlling
    /// the frequency of actions such as abilities, attacks, or other timed events.
    /// </summary>
    /// <remarks>
    /// The <see cref="Cooldown"/> class is a lightweight utility designed
    /// for generic use across gameplay systems. It tracks elapsed time
    /// and determines when an action can be executed again.
    /// 
    /// Example usage:
    /// <code>
    /// Cooldown attackCooldown = new Cooldown(2f);
    /// 
    /// if (attackCooldown.IsReady())
    /// {
    ///     PerformAttack();
    ///     attackCooldown.Use();
    /// }
    /// </code>
    /// </remarks>
    public class MDCooldownUtility
    {
        private float _cooldownTime;
        private float _lastUsedTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cooldown"/> class with the specified cooldown duration.
        /// </summary>
        /// <param name="cooldown">The cooldown duration, in seconds.</param>
        /// <param name="startReady">Determines the initial state of the cooldown.</param>
        public MDCooldownUtility(float cooldown, bool startReady = false)
        {
            _cooldownTime = cooldown;
            _lastUsedTime = startReady
                ? -cooldown // Force the cooldown to appear already expired,
                // allowing immediate use on the first check.
                : Time.time; // Start the cooldown now, requiring a full
            // cooldown duration before it becomes ready.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cooldown"/> class with the specified cooldown duration.
        /// </summary>
        /// <param name="startReady">Determines the initial state of the cooldown.</param>
        public MDCooldownUtility(bool startReady = false)
        {
            _lastUsedTime = startReady
                ? float.NegativeInfinity // Force the cooldown to appear already expired,
                // allowing immediate use on the first check.
                : Time.time; // Start the cooldown now, requiring a full
            // cooldown duration before it becomes ready.
        }

        /// <summary>
        /// Checks whether the cooldown has finished and is ready to be used again.
        /// </summary>
        /// <returns><c>true</c> if the cooldown is ready; otherwise, <c>false</c>.</returns>
        public bool IsReady()
        {
            return Time.time >= _lastUsedTime + _cooldownTime;
        }

        /// <summary>
        /// Marks the cooldown as used, starting the cooldown timer.
        /// </summary>
        public void Use()
        {
            _lastUsedTime = Time.time;
        }

        public void SetNewCooldownTime(float cooldown)
        {
            _cooldownTime = cooldown;
        }

        /// <summary>
        /// Returns the remaining cooldown time until the action is ready again.
        /// </summary>
        /// <returns>The remaining cooldown time, in seconds.</returns>
        public float TimeRemaining()
        {
            return Mathf.Max(0, (_lastUsedTime + _cooldownTime) - Time.time);
        }

        public static MDCooldownUtility Create(bool startReady = false)
        {
            return new MDCooldownUtility(startReady);
        }

        public static MDCooldownUtility Create(Vector2 cooldownTime, bool startReady = false)
        {
            return Create(cooldownTime.GetRandomBetween());
        }

        public static MDCooldownUtility Create(float cooldownTime, bool startReady = false)
        {
            return new MDCooldownUtility(cooldownTime);
        }
    }
}