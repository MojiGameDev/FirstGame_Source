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

        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Info", showLabel: false)] [HorizontalGroup("$" + nameof(GroupTitle) + "/Info/Group01")] [SerializeField] [HideLabel]
        private string title;

        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Info", showLabel: false)] [HorizontalGroup("$" + nameof(GroupTitle) + "/Info/Group01")] [SerializeField] [LabelText("CanSave?")] [OnValueChanged(nameof(OnCanSaveChanged))]
        protected bool canSave;

        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Info", showLabel: false)] [HorizontalGroup("$" + nameof(GroupTitle) + "/Info/Group01")] [SerializeField] [LabelText("IsGlobal?")] [ShowIf(nameof(canSave))] [OnValueChanged(nameof(OnIsGlobalChanged))]
        protected bool isGlobal;

        [FoldoutGroup("$" + nameof(GroupTitle))]
        [BoxGroup("$" + nameof(GroupTitle) + "/Key")]
        [Button("Generate Key")]
        [ShowIf(nameof(IsLocalKeyMustShowed))]
        private void GenerateLocalKey()
        {
            if (!string.IsNullOrEmpty(localKey) && SVSave.KeyExists(localKey))
            {
                SVSave.DeleteKey(localKey);
            }

            localKey = SVGeneralUtils.NewSaveKey();
            lastSavedKey = null;

            Save();
        }

        // Remembers the key associated with this variable's last save.
        [SerializeField] [HideInInspector] private string lastSavedKey;

        public string Title => title;
        public abstract Type Type { get; }
        public event Action<object> OnValueChanged;
        private string Key => isGlobal ? globalKey : localKey;

        protected string GroupTitle =>
            $"{(canSave ? "Saved - " : "")}" +
            $"{(isGlobal ? "Global - " : "Local - ")}" +
            $"{(string.IsNullOrEmpty(Title) ? "..." : Title)} " +
            $"({GetType().GetTitle()}) = {GetValue()}";

        private bool IsGlobalKeyMustShowed => canSave && isGlobal;
        private bool IsLocalKeyMustShowed => canSave && !isGlobal;

        public object Value
        {
            get => GetValue();
            set => SetValueInternal(value, notify: true, save: true);
        }

        public void SetTitle(string variableTitle)
        {
            title = variableTitle;
        }

        public void Save()
        {
            if (!canSave || string.IsNullOrEmpty(Key))
            {
                return;
            }

            SVSave.Save(Key, Value);
            lastSavedKey = Key;
        }

        public void Load()
        {
            if (!canSave || string.IsNullOrEmpty(Key))
            {
                return;
            }

            if (!SVSave.KeyExists(Key))
            {
                return;
            }

            var loadedValue = SVSave.Load<object>(Key);

            // Loading must not notify listeners or write the value back.
            SetValueInternal(loadedValue, notify: false, save: false);
            lastSavedKey = Key;
        }

        private void SetValueInternal(object newValue, bool notify, bool save)
        {
            if (newValue != null && !Type.IsInstanceOfType(newValue))
            {
                throw new ArgumentException(
                    $"Expected a value of type {Type.Name}, " +
                    $"but received {newValue.GetType().Name}.",
                    nameof(newValue));
            }

            var oldValue = GetValue();

            if (Equals(oldValue, newValue))
            {
                return;
            }

            SetValue(newValue);

            var currentValue = GetValue();

            if (notify)
            {
                OnValueChanged?.Invoke(currentValue);
            }

            if (save)
            {
                Save();
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
            if (canSave)
            {
                Save();
                return;
            }

            DeleteSavedKey();
        }

        private void OnGlobalKeyChanged()
        {
            HandleKeyChanged();
        }

        private void OnIsGlobalChanged()
        {
            HandleKeyChanged();
        }

        private void HandleKeyChanged()
        {
            DeleteSavedKey();
            Save();
        }

        private void DeleteSavedKey()
        {
            if (string.IsNullOrEmpty(lastSavedKey))
            {
                return;
            }

            if (SVSave.KeyExists(lastSavedKey))
            {
                SVSave.DeleteKey(lastSavedKey);
            }

            lastSavedKey = null;
        }

        [OnInspectorInit]
        private void OnInspectorInit()
        {
            if (string.IsNullOrEmpty(localKey))
            {
                localKey = SVGeneralUtils.NewSaveKey();
            }

            // Do not load runtime save data during Inspector initialization.
        }
    }
}