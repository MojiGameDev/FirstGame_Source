using __SARV.Common.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Trait.Base
{
    public abstract class SVBaseTrait : SVScriptableObject
    {
        [FoldoutGroup("Info")] [SerializeField]
        protected string title;

        [FoldoutGroup("Info")] [SerializeField] [MultiLineProperty(10)]
        protected string description;

        public string Title => title;
        public string Description => description;
    }
}