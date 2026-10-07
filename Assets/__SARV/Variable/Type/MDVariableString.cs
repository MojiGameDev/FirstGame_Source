// using System;
// using __MD.Script.Identifier;
// using __MD.Script.Mojo.Core.Attributes;
// using Sirenix.OdinInspector;
// using UnityEngine;
//
// namespace __MD.Script.Mojo.Variable
// {
//     [Serializable]
//     [MDTitle("String")]
//     public class MDVariableString : MDVariable
//     {
//         [SerializeField] [HideLabel] [HorizontalGroup("Group02")] [OnValueChanged(nameof(OnVariableValueChanged))]
//         private string variableValue;
//
//         public string StringValue => (string)Value;
//
//         protected override void OnVariableValueChanged()
//         {
//             if (canSave)
//             {
//                 Save(variableValue);
//             }
//         }
//
//         protected override object Get()
//         {
//             if (canSave && !IsLoaded)
//             {
//                 Load();
//             }
//
//             return variableValue;
//         }
//
//         protected override void Set(object newVariableValue)
//         {
//             if (newVariableValue is string value)
//             {
//                 variableValue = value;
//             }
//         }
//     }
// }