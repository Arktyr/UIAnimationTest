using System;
using UnityEngine;

namespace _Scripts.Extensions
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake() => 
            DontDestroyOnLoad(this);
    }
}