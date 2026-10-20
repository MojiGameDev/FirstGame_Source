using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using __SARV.Common.Base;
using __SARV.Framework.Common.Argument;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Enum;
using __SARV.Framework.Common.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Common.Shared
{
    [Serializable]
    public class SVBranch : SVSerializable
    {
        [BoxGroup("Row02", showLabel: false)] [HorizontalGroup("Row02/Group01")] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllBranchComponents))] [OnValueChanged(nameof(OnBranchChanged), InvokeOnInitialize = true)]
        private string branch = "";

        [BoxGroup("Row02", showLabel: false)]
        [HorizontalGroup("Row02/Group01", Width = 21)]
        [HideLabel]
        [Button(ButtonSizes.Medium, Icon = SdfIconType.Plus, ButtonHeight = 21)]
        [EnableIf(nameof(IsBranchValid))]
        private void AddNewBranch()
        {
            if (IsBranchValid)
            {
                var selectedComponentType = SVReflection.GetBranchByPath(branch);
                var instructionComponent = (SVBranchComponent)Activator.CreateInstance(selectedComponentType);
                branches.Add(instructionComponent);
                branch = "";
            }
        }

        [BoxGroup("Row03", showLabel: false)] [SerializeField] [LabelText("How to Join?")] [OnValueChanged(nameof(OnConditionJoinChanged))]
        private SVConditionJoinType conditionJoinType = SVConditionJoinType.And;
        
        [SerializeReference] [HideReferenceObjectPicker] [ListDrawerSettings(HideAddButton = true, ShowFoldout = false)] [OnValueChanged(nameof(OnBranchesChanged))]
        private List<SVBranchComponent> branches = new();

        private bool IsBranchValid => !string.IsNullOrEmpty(branch);
        public int BranchesCount => branches.Count;
        public SVConditionJoinType ConditionJoinType => conditionJoinType;

        public bool IsBranchesPassed(SVArgument argument)
        {
            var result = true;
            foreach (var branchComponent in branches.Where(d => !d.Disabled))
            {
                if (conditionJoinType == SVConditionJoinType.And && !branchComponent.IsTrue(argument))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private void OnBranchChanged()
        {
        }

        private void OnBranchesChanged()
        {
        }

        private void OnConditionJoinChanged()
        {
        }

        private IEnumerable GetAllBranchComponents()
        {
            var components = SVReflection.GetAllBranchComponentPaths();
            return components.Select(d => new ValueDropdownItem(d, d));
        }
    }
}