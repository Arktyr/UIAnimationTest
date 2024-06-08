using System;
using _Scripts.Game.Services.Settings;
using UnityEngine;

namespace _Scripts.Game.Services.Sound
{
    [Serializable]
    public struct SoundSourceData
    {
        public SoundGroupID SoundGroupID;
        public AudioSource AudioSource;
    }
}