using System.Collections.Generic;
using __SARV.Common.Base;
using __SARV.Framework.Module.Melee.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeCombo
{
    public abstract class SVSubMeleeComboNode : SVSubMeleeComboReaction
    {
        [FoldoutGroup("Combo")] [SerializeField] [ListDrawerSettings(CustomAddFunction = nameof(CreateNode))] [LabelText("$" + nameof(CombosLabel))]
        protected List<SVComboNode> combos = new();

        private string CombosLabel => $"{combos.Count} Combos";
        
        public IReadOnlyList<SVComboNode> Combos => combos;

        private void CreateNode()
        {
            combos.Add(new SVComboNode());
        }
    }
}