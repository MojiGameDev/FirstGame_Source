using System;
using __SARV.Core.Base;
using __SARV.Identifier;
using __SARV.Variable.Base;
using __SARV.Variable.Value;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Variable.Entity
{
    [Serializable]
    public class SVVariable : SVSerializable
    {
        [FoldoutGroup("$GroupTitle")] [BoxGroup("$GroupTitle/Info", showLabel: false)] [HorizontalGroup("$GroupTitle/Info/Group01")] [SerializeField] [HideLabel]
        private string title;

        [FoldoutGroup("$GroupTitle")] [BoxGroup("$GroupTitle/Info", showLabel: false)] [HorizontalGroup("$GroupTitle/Info/Group01")] [SerializeField] [LabelText("CanSave?")]
        private bool canSave;

        [FoldoutGroup("$GroupTitle")] [BoxGroup("$GroupTitle/Identifier")] [SerializeField] [HideLabel] [ShowIf(nameof(canSave))]
        private SVIdentifier identifier;

        [FoldoutGroup("$GroupTitle")] [BoxGroup("$GroupTitle/Value")] [SerializeReference] [HideLabel] [HideReferenceObjectPicker]
        private SVValue value = new SVValueNull();

        public SVIdentifier Identifier => identifier;
        public bool CanSave => canSave;
        public string Title => title;
        public string GroupTitle => title;

        public void SetTitle(string variableTitle)
        {
            title = variableTitle;
        }
    }
}