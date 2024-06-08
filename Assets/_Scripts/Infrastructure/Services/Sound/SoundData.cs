using System;
using UnityEngine;

namespace _Scripts.Game.Services.Sound
{
    [Serializable]
    public struct SoundData
    {
        public SoundID SoundID;
        public AudioClip AudioClip;
    }
}