using System.Collections.Generic;
using __SARV.Framework.Module.Melee.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Melee.SubMeleeWeapon
{
    public abstract class SVSubMeleeWeaponCombo : SVSubMeleeWeaponHandling
    {
        [FoldoutGroup("Combo")] [SerializeField] [ListDrawerSettings(CustomAddFunction = nameof(CreateNode))] [LabelText("$" + nameof(CombosLabel))]
        protected List<SVComboNode> combos = new();

        private string CombosLabel => $"{combos.Count} Combos";

        private void CreateNode()
        {
            combos.Add(new SVComboNode());
        }
    }
}