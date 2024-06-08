using System;
using _Scripts.Infrastructure.Services.Settings;
using UnityEngine;

namespace _Scripts.Infrastructure.Services.Sound
{
    [Serializable]
    public struct SoundSourceData
    {
        public SoundGroupID SoundGroupID;
        public AudioSource AudioSource;
    }
}