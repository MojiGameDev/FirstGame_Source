using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using __SARV.Common.Base;
using __SARV.Common.Extension;
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
        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Row02", showLabel: false)] [HorizontalGroup("$GroupTitle/Row02/Group01")] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetAllBranchComponents))] [OnValueChanged(nameof(OnBranchChanged), InvokeOnInitialize = true)]
        private string branch = "";

        [FoldoutGroup("$" + nameof(GroupTitle))]
        [BoxGroup("$" + nameof(GroupTitle) + "/Row02", showLabel: false)]
        [HorizontalGroup("$" + nameof(GroupTitle) + "/Row02/Group01", Width = 21)]
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

        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Row03", showLabel: false)] [SerializeField] [LabelText("How to Join?")] [OnValueChanged(nameof(OnConditionJoinChanged))]
        private SVConditionJoinType conditionJoinType = SVConditionJoinType.And;

        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Row03", showLabel: false)] [SerializeField] [LabelText("Not?")]
        private bool not;

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeReference] [HideReferenceObjectPicker] [ListDrawerSettings(HideAddButton = true, ShowFoldout = false)] [OnValueChanged(nameof(OnBranchesChanged))]
        private List<SVBranchComponent> branches = new();

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel] [DisplayAsString] [PropertySpace(spaceBefore: 10, spaceAfter: -20)] [InfoBox("Executes when the branches are true", InfoMessageType.Info)]
        private string trueTooltip = "";

        [FoldoutGroup("$" + nameof(GroupTitle))] [SerializeField] [HideLabel]
        private SVInstruction instruction;

        private bool IsBranchValid => !string.IsNullOrEmpty(branch);
        private string GroupTitle => $"Type : {conditionJoinType.ToReadableString()} - Not? {Not.ToName()} - {branches.Count} Branches";
        public bool Not => not;
        public SVInstruction Instruction => instruction;

        public bool IsBranchesPassed(SVArgument argument)
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