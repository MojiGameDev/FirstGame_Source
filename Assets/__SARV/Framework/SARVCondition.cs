using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using __SARV.Core.Base;
using __SARV.Core.Component;
using __SARV.Core.Enum;
using __SARV.Core.Reflection;
using __SARV.Framework.Argument;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework
{
    public class SARVCondition : SVInstructionMonoBehaviour
    {
        [BoxGroup("Purpose", showLabel: false)] [SerializeField] [HideLabel]
        private string description = "";

        [BoxGroup("Row02", showLabel: false)] [BoxGroup("Row02/InnerRow01", showLabel: false)] [HorizontalGroup("Row02/InnerRow01/Group01")] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllBranchComponents))] [OnValueChanged(nameof(OnBranchChanged), InvokeOnInitialize = true)]
        private string branch = "";

        [BoxGroup("Row02", showLabel: false)]
        [BoxGroup("Row02/InnerRow01", showLabel: false)]
        [HorizontalGroup("Row02/InnerRow01/Group01", Width = 21)]
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
        [BoxGroup("Row02", showLabel: false)] [BoxGroup("Row02/InnerRow01", showLabel: false)] [BoxGroup("Row02/InnerRow01/InnerRow02", showLabel: false)] [SerializeField] [LabelText("How to Join?")] [OnValueChanged(nameof(OnConditionJoinChanged))]
        private SVConditionJoinType conditionJoinType = SVConditionJoinType.And;

        [BoxGroup("Row02", showLabel: false)] [SerializeReference] [HideReferenceObjectPicker] [ListDrawerSettings(HideAddButton = true, ShowFoldout = false)] [OnValueChanged(nameof(OnBranchesChanged))]
        private List<SVBranchComponent> branches = new();

        [SerializeField] [HideLabel] [DisplayAsString] [PropertySpace(spaceBefore: 10, spaceAfter: -20)] [InfoBox("Execute the following instructions when the branches above are true", InfoMessageType.Info)]
        private string tooltip = "";

        public List<SVBranchComponent> Branches => branches;
        private bool IsBranchValid => !string.IsNullOrEmpty(branch);

        public async Task RunCondition(SVArgument argument)
        {
            if (IsBranchesPassed(argument))
            {
                await ExecuteInstructions(argument);
            }
        }

        private bool IsBranchesPassed(SVArgument argument)
        {
            foreach (var branchComponent in branches.Where(d => !d.Disabled))
            {
                if (conditionJoinType == SVConditionJoinType.And && !branchComponent.IsTrue(argument))
                {
                    return false;
                }
            }

            return true;
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