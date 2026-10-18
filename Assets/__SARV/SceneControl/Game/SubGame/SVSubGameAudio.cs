using System.Collections.Generic;
using __SARV.Framework.Integration.MasterAudio.Wrapper;
using __SARV.Framework.Module.Identifier;
using DarkTonic.MasterAudio;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.SceneControl.Game.SubGame
{
    public abstract class SVSubGameAudio : SVSubGamePool
    {
        [FoldoutGroup("Audio")] [SerializeField] [TableList] [LabelText("Wrappers")]
        private List<SVWrapperMasterAudioIdentifier> audioWrappers = new();

        private readonly Dictionary<SARVIdentifier, string> RuntimeAudioNames = new();

        private const string DIALOGUE_GROUP_NAME = "Dialogue";
        private const string DIALOGUE_VARIATION_NAME = "CurrentLine";

        protected override void Awake()
        {
            base.Awake();
            HandleWrappersToDictionary();
        }

        public void PlayDialogue(AudioClip clip)
        {
            StopAudio(DIALOGUE_GROUP_NAME);

            if (clip == null)
            {
                return;
            }

            MasterAudio.ChangeVariationClip(
                DIALOGUE_GROUP_NAME,
                false,
                DIALOGUE_VARIATION_NAME,
                clip
            );

            MasterAudio.PlaySound(
                DIALOGUE_GROUP_NAME,
                variationName: DIALOGUE_VARIATION_NAME
            );
        }

        private void StopAudio(string groupName)
        {
            MasterAudio.StopAllOfSound(groupName);
        }

        private void HandleWrappersToDictionary()
        {
            foreach (var wrapper in audioWrappers)
            {
                RuntimeAudioNames.Add(wrapper.Identifier, wrapper.ClipName);
            }
        }
    }
}