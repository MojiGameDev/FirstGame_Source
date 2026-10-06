using System.Linq;
using __MD.Script.WeeklyMap.Editor.Enum;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __MD.Script.WeeklyMap.Editor.SubWeeklyMap
{
    public abstract class MDSubWeeklyMapProgress : MDSubWeeklyMapTask
    {
        [BoxGroup("Progress", showLabel: false)] [HideLabel] [SerializeField] [ProgressBar(0, "$totalCount", ColorGetter = nameof(GetDoneColor), BackgroundColorGetter = nameof(GetBackgroundColor), DrawValueLabel = false, Height = 30)]
        private float progress;

        [BoxGroup("Progress", showLabel: false)] [SerializeField] [ReadOnly]
        private int totalCount;

        [BoxGroup("Progress", showLabel: false)] [SerializeField] [ReadOnly]
        private int inProgressCount;

        [BoxGroup("Progress", showLabel: false)] [SerializeField] [ReadOnly]
        private int completedCount;

        [BoxGroup("Progress", showLabel: false)] [SerializeField] [ReadOnly]
        private int failedCount;

        protected override void OnTasksChanged()
        {
            totalCount = tasks.Count;
            inProgressCount = tasks.Count(d => d.Status is MDTaskStatus.InProgress);
            completedCount = tasks.Count(d => d.Status is MDTaskStatus.Complete);
            failedCount = tasks.Count(d => d.Status is MDTaskStatus.Failed);
            progress = completedCount % 100.01f;
        }

        private Color GetDoneColor()
        {
            return Color.green;
        }

        private Color GetBackgroundColor()
        {
            return Color.red;
        }
    }
}