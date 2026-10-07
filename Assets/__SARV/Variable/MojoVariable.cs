// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using __MD.Script.Mojo.Variable;
// using __SARV.Core.Base;
// using Sirenix.OdinInspector;
// using UnityEngine;
//
// namespace __MD.Script.Mojo
// {
//     public class MojoVariable : SVMonoBehaviour
//     {
//         [BoxGroup("Row01", showLabel: false)] [BoxGroup("Row01/InnerRow01", showLabel: false)] [HorizontalGroup("Row01/InnerRow01/Group01")] [SerializeField] [HideLabel] [ValueDropdown(nameof(GetVariableTypes))]
//         private string variable;
//
//         [BoxGroup("Row01", showLabel: false)]
//         [BoxGroup("Row01/InnerRow01", showLabel: false)]
//         [HorizontalGroup("Row01/InnerRow01/Group01", Width = 21)]
//         [HideLabel]
//         [Button(ButtonSizes.Medium, Icon = SdfIconType.Plus, ButtonHeight = 21)]
//         [EnableIf(nameof(NewVariableFormIsValid))]
//         private void AddNewVariable()
//         {
//             if (NewVariableFormIsValid())
//             {
//                 // var variableType = MDMojoReflection.FindVariableByTitle(variable);
//                 // var variableInstance = (MDVariable)Activator.CreateInstance(variableType);
//                 // variableInstance?.Make(identifier);
//                 // variables.Add(variableInstance);
//                 // identifier = null;
//             }
//             else
//             {
//                 Debug.Log("NewVariableFormIsValid failed");
//             }
//         }
//
//         [BoxGroup("Row01", showLabel: false)] [SerializeReference] [HideReferenceObjectPicker] [ListDrawerSettings(DraggableItems = true, ShowPaging = false, ShowItemCount = true, HideRemoveButton = false, ShowFoldout = false, HideAddButton = true, CustomRemoveIndexFunction = nameof(HandleRemoveVariable))]
//         private List<MDVariable> variables = new();
//
//         public readonly Dictionary<string, MDVariable> RuntimeVariables = new();
//
//         private void Awake()
//         {
//             HandleVariablesToDictionary();
//         }
//
//         private bool NewVariableFormIsValid()
//         {
//             if (string.IsNullOrEmpty(type))
//             {
//                 return false;
//             }
//
//             if (variables.Any(d => d.Identifier == identifier))
//             {
//                 return false;
//             }
//
//             if (!MDMojoReflection.ExistVariableByTitle(type))
//             {
//                 return false;
//             }
//
//             return true;
//         }
//
//         private void HandleRemoveVariable(int index)
//         {
//             variables.RemoveAt(index);
//         }
//
//         private void HandleVariablesToDictionary()
//         {
//             foreach (var variable in variables)
//             {
//                 RuntimeVariables.Add(variable.Identifier, variable);
//             }
//         }
//
//         private IEnumerable GetVariableTypes()
//         {
//             return MDMojoReflection.GetAllTitles().Select(d => new ValueDropdownItem(d, d));
//         }
//     }
// }