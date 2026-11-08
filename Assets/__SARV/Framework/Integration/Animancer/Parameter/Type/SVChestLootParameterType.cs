using System;
using __SARV.Framework.Integration.Animancer.Enum;
using UnityEngine;

namespace __SARV.Framework.Integration.Animancer.Parameter.Type
{
    [Serializable]
    public struct SVChestLootParameterType
    {
        [SerializeField] private SVChestLootPhase lootPhase;

        public SVChestLootPhase LootPhase => lootPhase;
    }
}