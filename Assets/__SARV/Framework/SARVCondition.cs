using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using __SARV.Core.Base;
using __SARV.Core.Component;
using __SARV.Core.Enum;
using __SARV.Core.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework
{
    public class SARVCondition : SVMonoBehaviour
    {
        [BoxGroup("Row01", showLabel: false)] [HorizontalGroup("Row01/Group01")] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllBranchComponents))] [OnValueChanged(nameof(OnBranchChanged), InvokeOnInitialize = true)]
        private string branch = "";

        [BoxGroup("Row01", showLabel: false)]
        [HorizontalGroup("Row01/Group01", Width = 21)]
        [HideLabel]
        [Button(ButtonSizes.Medium, Icon = SdfIconType.Plus, ButtonHeight = 21)]
        [EnableIf(nameof(IsBranchValid))]
        private void AddNewBranch()
        {
            if (IsBranchValid)
            {
                var selectedComponentType = SVReflection.GetBranchByPath(branch);
                var instructionComponent = (SVBranchComponent)Activator.CreateInstance(selectedComponentType);
                Branches.Add(instructionComponent);
                branch = "";
            }
        }
        
        [SerializeReference] [HideReferenceObjectPicker] [ListDrawerSettings(HideAddButton = true, ShowFoldout = false)] [OnValueChanged(nameof(OnBranchesChanged))]
        private List<SVBranchComponent> branches = new();

        [BoxGroup("Row01", showLabel: false)] [BoxGroup("Row01/InnerRow02", showLabel: false)] [SerializeField] [LabelText("How to Join?")] [OnValueChanged(nameof(OnConditionJoinChanged))]
        private SVConditionJoinType conditionJoinType = SVConditionJoinType.And;

        public List<SVBranchComponent> Branches => branches;
        private bool IsBranchValid => !string.IsNullOrEmpty(branch);
        
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