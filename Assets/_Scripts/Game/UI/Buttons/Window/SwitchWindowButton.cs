﻿using System;
using _Scripts.Game.Services.Sound;
using _Scripts.UI.Windows;
using _Scripts.UI.Windows.Switch;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Game.UI.Buttons
{
    public class SwitchWindowButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private WindowID _windowID;
        [SerializeField] private WindowSwitcher _windowSwitcher;

        private void Awake() => 
            _button.onClick.AddListener(SwitchWindow);

        private void SwitchWindow() => 
            _windowSwitcher.SwitchWindow(_windowID);

        private void OnDestroy() => 
            _button.onClick.RemoveAllListeners();
    }
}