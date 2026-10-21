using System;
using __SARV.Framework.Module.Footstep;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Actor.Player.SubPlayer
{
    public abstract class SVSubPlayerFootstep : SVSubPlayerAnimancer
    {
        [FoldoutGroup("Footstep")] [SerializeField] [HideLabel]
        private SVFootstep footstep;

        public SVFootstep Footstep => footstep;

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            Footstep.HandleOnDrawGizmos();
        }

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            Footstep.HandleOnDrawGizmosSelected();
        }
    }
}