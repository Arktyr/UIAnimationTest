using System;
using System.Collections.Generic;
using _Scripts.Game.Services.Settings;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace _Scripts.Game.Services.Sound
{
    public class SoundService : MonoBehaviour, ISoundService
    {
        [SerializeField] private List<SoundData> _audioClips;
        [SerializeField] private List<SoundSourceData> _audioSources;

        public void PlaySoundInLoop(SoundID soundID, SoundGroupID soundGroupID)
        {
            if (TryFindClip(soundID, out AudioClip clip) == false)
                return;
            
            if (TryFindSource(soundGroupID, out AudioSource audioSource) == false)
                return;
            
            Debug.Log(clip.name);
            Debug.Log(soundID);
            Debug.Log(soundGroupID);
            audioSource.clip = clip;
            audioSource.loop = true;
            audioSource.Play();
        }

        public void PlayerSoundOneShot(SoundID soundID, SoundGroupID soundGroupID)
        {
            if (TryFindClip(soundID, out AudioClip clip) == false)
                return;
            
            if (TryFindSource(soundGroupID, out AudioSource audioSource) == false)
                return;
            
            audioSource.PlayOneShot(clip);
        }

        private bool TryFindClip(SoundID soundID, out AudioClip audioClip)
        {
            foreach (var clip in _audioClips)
            {
                if (soundID != clip.SoundID)
                    continue;
                
                audioClip = clip.AudioClip;
                return true;
            }

            audioClip = null;
            return false;
        }

        private bool TryFindSource(SoundGroupID soundGroupID, out AudioSource audioSource)
        {
            foreach (var source in _audioSources)
            {
                if (source.SoundGroupID != soundGroupID)
                    continue;

                audioSource = source.AudioSource;
                return true;
            }

            audioSource = null;
            return false;
        }
    }
}