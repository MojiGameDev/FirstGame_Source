using __SARV.Framework.Module.Trait.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Trait
{
    [CreateAssetMenu(fileName = "Attribute", menuName = "SARV/Trait/Attribute")]
    public class SVAttribute : SVBaseRuntimeTrait
    {
        [BoxGroup("Runtime")] [SerializeField] private float minValue;
        [BoxGroup("Runtime")] [SerializeField] private SVStat maxValueStat;
    }
}