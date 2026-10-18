using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private SoundGroupVariation.SoundFinishedEventHandler _soundFinishedHandler;

        protected override void Awake()
        {
            base.Awake();
            HandleWrappersToDictionary();
        }

        public async Task PlayDialogue(AudioClip clip, bool waitForCompletion)
        {
            StopAudio(DIALOGUE_GROUP_NAME);

            if (clip == null)
                return;

            MasterAudio.ChangeVariationClip(
                DIALOGUE_GROUP_NAME,
                false,
                DIALOGUE_VARIATION_NAME,
                clip
            );

            var result = MasterAudio.PlaySound(
                DIALOGUE_GROUP_NAME,
                variationName: DIALOGUE_VARIATION_NAME
            );

            if (!waitForCompletion || result?.ActingVariation == null)
            {
                return;
            }

            var variation = result.ActingVariation;
            var completion = new TaskCompletionSource<bool>();

            SoundGroupVariation.SoundFinishedEventHandler handler = null;

            handler = () =>
            {
                variation.SoundFinished -= handler;
                completion.TrySetResult(true);
            };

            variation.SoundFinished += handler;

            await completion.Task;
        }

        public void PlayDialogue(AudioClip clip, Action onAudioFinished = null)
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

            var playSoundResult = MasterAudio.PlaySound(
                DIALOGUE_GROUP_NAME,
                variationName: DIALOGUE_VARIATION_NAME
            );

            if (playSoundResult?.ActingVariation == null || onAudioFinished == null)
            {
                return;
            }

            var variation = playSoundResult.ActingVariation;

            _soundFinishedHandler = () =>
            {
                variation.SoundFinished -= _soundFinishedHandler;
                onAudioFinished.Invoke();
            };

            variation.SoundFinished += _soundFinishedHandler;
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