﻿using _Scripts.Game.Services.Windows.Switch;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Game.UI.Buttons.Window
{
    public class CloseWindowButton : MonoBehaviour
    {
        [SerializeField] private WindowSwitcher _windowSwitcher;
        [SerializeField] private Button _button;

        private void Awake() => 
            _button.onClick.AddListener(SwitchWindow);

        private void SwitchWindow() => 
            _windowSwitcher.CloseWindow();

        private void OnDestroy() => 
            _button.onClick.RemoveAllListeners();
    }
}