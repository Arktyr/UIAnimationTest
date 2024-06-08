using System;
using UnityEngine;
using UnityEngine.Audio;

namespace _Scripts.Game.Services.Settings
{
    public class SettingsService : MonoBehaviour, ISettingsService
    {
        private const string SOUNDSGROUP = "SoundsVolume";
        private const string MUSICSGROUP = "MusicVolume";
        
        [SerializeField] private AudioMixer _audioMixer;

        public void SetSoundsVolume(SoundGroupID soundGroupID, float value)
        {
            switch (soundGroupID)
            {
                case SoundGroupID.Sounds:
                    PlayerPrefs.SetFloat(SOUNDSGROUP, value);
                    _audioMixer.SetFloat(SOUNDSGROUP, value);
                    break;
                case SoundGroupID.Music:
                    PlayerPrefs.SetFloat(MUSICSGROUP, value);
                    _audioMixer.SetFloat(MUSICSGROUP, value);
                    break;
                default:
                    Debug.LogError($"{soundGroupID}: This Sound Group Not Found");
                    break;
            }
        }

        public void UpdateData()
        {
            float soundValue = PlayerPrefs.GetFloat(SOUNDSGROUP);
            float musicValue = PlayerPrefs.GetFloat(MUSICSGROUP);

            _audioMixer.SetFloat(SOUNDSGROUP, soundValue);
            _audioMixer.SetFloat(MUSICSGROUP, musicValue);
        }
    }
}