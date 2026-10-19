using System;
using __SARV.Common.Base;
using __SARV.Common.Extension;
using __SARV.Framework.Common.Utils;
using __SARV.Framework.Integration.EasySave;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Variable.Base
{
    [Serializable]
    public abstract class SVVariable : SVSerializable
    {
        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Key", showLabel: false)] [SerializeField] [HideLabel] [ShowIf(nameof(canSave))]
        protected string key;

        [FoldoutGroup("$GroupTitle")]
        [BoxGroup("$GroupTitle/Key")]
        [ShowIf(nameof(canSave))]
        [Button]
        [ShowIf(nameof(MustShowGenerateKey))]
        private void GenerateKey()
        {
            key = SVGeneralUtils.NewSaveKey();
        }

        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Info", showLabel: false)] [HorizontalGroup("$GroupTitle/Info/Group01")] [SerializeField] [HideLabel]
        private string title;

        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Info", showLabel: false)] [HorizontalGroup("$GroupTitle/Info/Group01")] [SerializeField] [LabelText("CanSave?")] [OnValueChanged(nameof(OnCanSaveChanged))]
        protected bool canSave;

        private bool MustShowGenerateKey => canSave;
        public string Title => title;
        public string GroupTitle => $"{(canSave ? "Saved - " : "")}{(string.IsNullOrEmpty(Title) ? "..." : Title)} ({GetType().GetTitle()}) = {GetValue()}";

        public event Action<object> OnValueChanged;

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
            if (!canSave || string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            ES3.Save(key, Value);
        }

        public void Load()
        {
            if (!canSave || string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            if (ES3.KeyExists(key))
            {
                Value = ES3.Load<object>(key);
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
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            if (canSave)
            {
                Save();
            }
            else if (ES3.KeyExists(key))
            {
                ES3.DeleteKey(key);
            }
        }
    }
}