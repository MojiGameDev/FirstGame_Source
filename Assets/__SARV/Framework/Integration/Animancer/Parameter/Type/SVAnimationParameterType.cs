using System;
using __SARV.Framework.Integration.Animancer.Enum;
using UnityEngine;

namespace __SARV.Framework.Integration.Animancer.Parameter.Type
{
    [Serializable]
    public struct SVAnimationParameterType
    {
        [SerializeField] private SVMAnimationPhase animationPhase;

        public SVMAnimationPhase AnimationPhase => animationPhase;
    }
}