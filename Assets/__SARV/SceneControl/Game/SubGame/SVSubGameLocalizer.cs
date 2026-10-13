using System.Collections.Generic;
using __SARV.Framework.Module.Identifier;
using __SARV.Framework.Module.Localizer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.SceneControl.Game.SubGame
{
    public abstract class SVSubGameLocalizer : SVSubGameReference
    {
        [FoldoutGroup("Localizer")] [SerializeField]
        private List<SARVLocalizer> names = new();

        [FoldoutGroup("Localizer")] [SerializeField]
        private List<SARVLocalizer> dialogues = new();
        
        protected override void Awake()
        {
            base.Awake();
        }
    }
}