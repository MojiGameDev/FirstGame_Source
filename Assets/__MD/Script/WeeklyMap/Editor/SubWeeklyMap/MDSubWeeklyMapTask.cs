using System.Collections.Generic;
using __MD.Script.WeeklyMap.Editor.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __MD.Script.WeeklyMap.Editor.SubWeeklyMap
{
    public abstract class MDSubWeeklyMapTask : MDSubWeeklyMapOwner
    {
        [SerializeField] [BoxGroup("Task")] [OnValueChanged(nameof(OnTasksChanged), includeChildren: true, InvokeOnInitialize = true)]
        protected List<MDTask> tasks = new();

        protected virtual void OnTasksChanged()
        {
        }
    }
}