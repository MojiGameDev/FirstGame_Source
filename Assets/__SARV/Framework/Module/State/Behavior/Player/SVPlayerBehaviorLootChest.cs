using System;
using System.Threading.Tasks;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Module.State.Behavior.Base;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.State.Behavior
{
    [SVTitle("LootChest")]
    [SVCategory(SVConstantCategory.Behavior.PLAYER)]
    [SVDescription("Handles player interaction with loot chests")]
    [Serializable]
    public class SVPlayerBehaviorLootChest : SVPlayerInteractBehavior
    {
        [BoxGroup("Animancer")] [SerializeField] [Required]
        private StringAsset transitionAlias;

        public override async Task Enter()
        {
            await base.Enter();
            Actor.PlayAnimancer(transitionAlias);
        }
    }
}