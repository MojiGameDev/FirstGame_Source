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

        [FoldoutGroup("$" + nameof(GroupTitle))] [BoxGroup("$" + nameof(GroupTitle) + "/Info", showLabel: false)] [HorizontalGroup("$GroupTitle/Info/Group01")] [SerializeField] [LabelText("CanSave?")]
        protected bool canSave;

        private bool MustShowGenerateKey => canSave;
        public string Title => title;
        public string GroupTitle => $"{(canSave ? "Saved - " : "")}{(string.IsNullOrEmpty(Title) ? "..." : Title)} ({GetType().GetTitle()}) = {Get()}";

        public event Action<object> OnValueChanged;

        public object Value
        {
            get
            {
                if (canSave)
                {
                    return SVEasySave.Load(key);
                }

                return Get();
            }
            set
            {
                if (Get() == value)
                {
                    return;
                }

                Set(value);

                if (canSave)
                {
                    SVEasySave.Save(key, value);
                }

                OnValueChanged?.Invoke(Get());
            }
        }

        public abstract Type Type { get; }

        public void SetTitle(string variableTitle)
        {
            title = variableTitle;
        }

        protected abstract object Get();
        protected abstract void Set(object newValue);
        protected abstract void Save();
        protected abstract void Load();
        public abstract override string ToString();
    }
}