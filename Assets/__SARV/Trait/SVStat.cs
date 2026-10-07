using System.Collections.Generic;
using __SARV.Trait.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Trait
{
    [CreateAssetMenu(fileName = "Stat", menuName = "SARV/Trait/Stat")]
    public class SVStat : SVBaseRuntimeTrait
    {
        [BoxGroup("Runtime")] [SerializeField] private List<SVModifier> modifiers = new();

        public List<SVModifier> Modifiers => modifiers;
    }
}