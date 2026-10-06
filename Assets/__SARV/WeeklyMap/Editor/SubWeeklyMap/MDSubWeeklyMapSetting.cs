using __MD.Script.WeeklyMap.Editor.Enum;
using __SARV.Core.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __MD.Script.WeeklyMap.Editor.SubWeeklyMap
{
    public abstract class MDSubWeeklyMapOwner : SVScriptableObject
    {
        [SerializeField] [BoxGroup("Owner")] private MDTaskOwner taskOwner = MDTaskOwner.Moni;
    }
}