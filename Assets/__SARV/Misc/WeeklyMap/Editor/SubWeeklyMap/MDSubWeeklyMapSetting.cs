using __SARV.Core.Base;
using __SARV.Misc.WeeklyMap.Editor.Enum;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Misc.WeeklyMap.Editor.SubWeeklyMap
{
    public abstract class MDSubWeeklyMapOwner : SVScriptableObject
    {
        [SerializeField] [BoxGroup("Owner")] private MDTaskOwner taskOwner = MDTaskOwner.Moni;
    }
}