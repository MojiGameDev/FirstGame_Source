using __SARV.Core.Base;
using __SARV.WeeklyMap.Editor.Enum;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.WeeklyMap.Editor.SubWeeklyMap
{
    public abstract class MDSubWeeklyMapOwner : SVScriptableObject
    {
        [SerializeField] [BoxGroup("Owner")] private MDTaskOwner taskOwner = MDTaskOwner.Moni;
    }
}