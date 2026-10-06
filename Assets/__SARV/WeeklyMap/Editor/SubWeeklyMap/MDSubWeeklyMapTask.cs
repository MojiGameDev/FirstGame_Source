using System.Collections.Generic;
using __SARV.WeeklyMap.Editor.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.WeeklyMap.Editor.SubWeeklyMap
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