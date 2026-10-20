using System;
using __SARV.Common.Base;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Utils;
using __SARV.Framework.Integration.EasySave;
using __SARV.Framework.Module.Identifier;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Variable.Base
{
    [Serializable]
    public abstract class SVVariable : SVSerializable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Key", showLabel: false)] [SerializeField] [HideLabel] [Required] [ShowIf(nameof(IsLocalKeyMustShowed))]
        protected string localKey;

        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Key", showLabel: false)] [SerializeField] [HideLabel] [Required] [ShowIf(nameof(IsGlobalKeyMustShowed))] [OnValueChanged(nameof(OnGlobalKeyChanged))]
        protected SARVIdentifier globalKey;

        [FoldoutGroup("$GroupTitle")]
        [BoxGroup("$GroupTitle/Key")]
        [Button("GenerateKey")]
        [ShowIf(nameof(IsLocalKeyMustShowed))]
        private void GenerateLocalKey()
        {
            if (!string.IsNullOrEmpty(localKey) && SVSave.KeyExists(Key))
            {
                SVSave.DeleteKey(localKey);
            }

            localKey = SVGeneralUtils.NewSaveKey();
            Save();
        }

        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Info", showLabel: false)] [HorizontalGroup("$GroupTitle/Info/Group01")] [SerializeField] [HideLabel]
        private string title;

        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Info", showLabel: false)] [HorizontalGroup("$GroupTitle/Info/Group01")] [SerializeField] [LabelText("CanSave?")] [OnValueChanged(nameof(OnCanSaveChanged))]
        protected bool canSave;

        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Info", showLabel: false)] [HorizontalGroup("$GroupTitle/Info/Group01")] [SerializeField] [LabelText("IsGlobal?")] [ShowIf(nameof(canSave))] [OnValueChanged(nameof(OnIsGlobalChanged))]
        protected bool isGlobal;

        public string Title => title;
        protected string GroupTitle => $"{(canSave ? "Saved - " : "")}{(isGlobal ? "Global - " : "Local - ")}{(string.IsNullOrEmpty(Title) ? "..." : Title)} ({GetType().GetTitle()}) = {GetValue()}";
        private bool IsGlobalKeyMustShowed => canSave && isGlobal;
        private bool IsLocalKeyMustShowed => canSave && !isGlobal;
        public event Action<object> OnValueChanged;
        private string Key => isGlobal ? globalKey : localKey;

        public object Value
        {
            get => GetValue();
            set
            {
                if (Equals(GetValue(), value))
                {
                    return;
                }

                SetValue(value);

                OnValueChanged?.Invoke(GetValue());

                Save();
            }
        }

        public abstract Type Type { get; }

        public void SetTitle(string variableTitle)
        {
            title = variableTitle;
        }

        public void Save()
        {
            if (!canSave || string.IsNullOrWhiteSpace(Key))
            {
                return;
            }

            SVSave.Save(Key, Value);
        }

        public void Load()
        {
            if (!canSave || string.IsNullOrEmpty(Key))
            {
                return;
            }

            if (SVSave.KeyExists(Key))
            {
                Value = SVSave.Load<object>(Key);
            }
        }

        protected abstract object GetValue();
        protected abstract void SetValue(object newValue);
        public abstract override string ToString();

        protected void OnInspectorValueChanged()
        {
            Save();
        }

        private void OnCanSaveChanged()
        {
            if (Key == null || string.IsNullOrEmpty(Key))
            {
                return;
            }

            if (canSave)
            {
                Save();
            }
            else if (SVSave.KeyExists(Key))
            {
                SVSave.DeleteKey(Key);
            }
        }

        private void OnGlobalKeyChanged()
        {
            Save();
        }

        private void OnIsGlobalChanged()
        {
            Save();
        }

        [OnInspectorInit]
        private void OnInspectorInit()
        {
            if (string.IsNullOrEmpty(localKey))
            {
                GenerateLocalKey();
            }

            Load();
        }
    }
}