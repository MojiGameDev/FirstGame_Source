using __SARV.Trait.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Trait
{
    [CreateAssetMenu(fileName = "Formula", menuName = "SARV/Trait/Formula")]
    public class SVFormula : SVBaseTrait
    {
        /// <summary>
        ///  e.g., "[Vitality] * 10 + [Strength] * 2"
        /// </summary>
        [FoldoutGroup("Data")] [SerializeField] [Required]
        private string expression;
    }
}