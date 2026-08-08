using __MD.Script.Core.Base;
using __MD.Script.WeeklyMap.Editor.Enum;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __MD.Script.WeeklyMap.Editor.SubWeeklyMap
{
    public abstract class MDSubWeeklyMapOwner : MDScriptableObject
    {
        [SerializeField] [BoxGroup("Owner")] private MDTaskOwner taskOwner = MDTaskOwner.Moni;
    }
}