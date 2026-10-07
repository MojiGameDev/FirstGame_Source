// using System;
// using __SARV.Core.Base;
// using __SARV.Identifier;
// using Sirenix.OdinInspector;
// using UnityEngine;
//
// namespace __MD.Script.Mojo.Variable
// {
//     [Serializable]
//     public abstract class MDVariable : SVSerializable
//     {
//         [SerializeField] [ReadOnly] [HideLabel]
//         protected SVIdentifier identifier;
//
//         [SerializeField] [LabelText("CanSave?")] [HorizontalGroup("Group01", 80)] [OnValueChanged(nameof(OnCanSaveChanged))]
//         protected bool canSave;
//         
//         protected bool IsLoaded = false;
//
//         public SVIdentifier Identifier => identifier;
//
//         public object Value
//         {
//             get => Get();
//             set
//             {
//                 if (Get() == value)
//                 {
//                     return;
//                 }
//
//                 if (canSave)
//                 {
//                     Save(value);
//                 }
//
//                 Set(value);
//             }
//         }
//
//         protected abstract void OnVariableValueChanged();
//         protected abstract object Get();
//         protected abstract void Set(object newVariableValue);
//
//         public void Make(MDIdentifier newIdentifier)
//         {
//             identifier = newIdentifier;
//             SetIdentifierTitle();
//         }
//
//         private void SetIdentifierTitle()
//         {
//             identifierTitle = identifier.SkipWords(2);
//         }
//         
//
//         protected void Load()
//         {
//             if (!canSave)
//             {
//                 return;
//             }
//
//             if (MDOldSave.Exists(this))
//             {
//                 var loadedVariable = MDOldSave.Load<object>(this);
//                 Set(loadedVariable);
//             }
//
//             IsLoaded = true;
//         }
//
//         protected void Save(object currentValue)
//         {
//             MDOldSave.Save(this, currentValue);
//         }
//
//         // protected string GetSaveKey()
//         // {
//         //     return $"{GetType().Name}_{id}";
//         // }
//
//         private void OnCanSaveChanged()
//         {
//             if (!canSave && MDOldSave.Exists(this))
//             {
//                 MDOldSave.Delete(this);
//             }
//
//             if (canSave)
//             {
//                 NewId();
//             }
//         }
//     }
// }