using System.Collections.Generic;
using __SARV.Common.Base;
using __SARV.Misc.WorldPosition.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Misc.WorldPosition
{
    public class SARVWorldPosition : SVMonoBehaviour
    {
        [SerializeField] [ListDrawerSettings(HideAddButton = true)]
        private List<SVPositionItem> positions = new();

        [Button]
        private void SaveCurrentPosition()
        {
            positions.Add(new SVPositionItem("", gameObject, gameObject.transform.position));
        }
    }
}