using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using __SARV.Common.Base;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Enum;
using __SARV.Framework.Common.Reflection;
using __SARV.Framework.Kernal.Argument;
using __SARV.Framework.Kernal.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Kernal
{
    public class SARVCondition : SVMonoBehaviour
    {
        [BoxGroup("Purpose", showLabel: false)] [SerializeField] [HideLabel]
        private string description = "";

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
                Branches.Add(instructionComponent);
                branch = "";
            }
        }

        [BoxGroup("Row03", showLabel: false)] [SerializeField] [LabelText("How to Join?")] [OnValueChanged(nameof(OnConditionJoinChanged))]
        private SVConditionJoinType conditionJoinType = SVConditionJoinType.And;

        [BoxGroup("Row03", showLabel: false)] [SerializeField] [LabelText("Not?")]
        private bool not = false;

        [SerializeReference] [HideReferenceObjectPicker] [ListDrawerSettings(HideAddButton = true, ShowFoldout = false)] [OnValueChanged(nameof(OnBranchesChanged))]
        private List<SVBranchComponent> branches = new();

        [SerializeField] [HideLabel] [DisplayAsString] [PropertySpace(spaceBefore: 10, spaceAfter: -20)] [InfoBox("Executes when the branches are true", InfoMessageType.Info)]
        private string trueTooltip = "";

        [SerializeField] [HideLabel] private SVInstruction trueInstruction;

        [SerializeField] [HideLabel] [DisplayAsString] [PropertySpace(spaceBefore: 10, spaceAfter: -20)] [InfoBox("Executes when the branches are false", InfoMessageType.Info)]
        private string falseTooltip = "";

        [SerializeField] [HideLabel] private SVInstruction falseInstruction;

        public List<SVBranchComponent> Branches => branches;
        private bool IsBranchValid => !string.IsNullOrEmpty(branch);

        public async Task RunCondition(SVArgument argument)
        {
            if (not)
            {
                if (IsBranchesPassed(argument))
                {
                    await falseInstruction.ExecuteInstructions(argument);
                }
                else
                {
                    await trueInstruction.ExecuteInstructions(argument);
                }
            }
            else
            {
                if (IsBranchesPassed(argument))
                {
                    await trueInstruction.ExecuteInstructions(argument);
                }
                else
                {
                    await falseInstruction.ExecuteInstructions(argument);
                }
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