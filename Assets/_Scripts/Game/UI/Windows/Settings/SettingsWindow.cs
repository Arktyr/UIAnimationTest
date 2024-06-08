using System;
using System.Collections.Generic;
using _Scripts.Game.Animations.Window;
using _Scripts.Game.Services.Settings;
using _Scripts.Game.UI.Buttons.Toggles;
using _Scripts.Infrastructure.Installer;
using _Scripts.Infrastructure.Singleton;
using _Scripts.UI.Windows;
using UnityEngine;

namespace _Scripts.Game.UI.Windows.Settings
{
    public class SettingsWindow : IInjectable, IWindow
    {
        [SerializeField] private WindowAnimation _windowAnimation;
        [SerializeField] private List<SoundToggle> _soundToggles;

        private ISettingsService _settingsService;
        
        public override void Inject()
        {
            _settingsService = AllServices.Container.GetSingle<ISettingsService>();
        }

        private void Awake()
        {
            foreach (var toogle in _soundToggles) 
                toogle.OnValueChanged += SwitchSoundSettings;
        }

        public void Open()
        {
            gameObject.SetActive(true);
            
            _windowAnimation.ShowWindow(default);
        }

        private void SwitchSoundSettings(float value, SoundGroupID soundGroupID) => 
            _settingsService.SetSoundsVolume(soundGroupID, value);

        public void Close() => 
            _windowAnimation.HideWindow(() => gameObject.SetActive(false));

        private void OnDestroy()
        {
            foreach (var toogle in _soundToggles) 
                toogle.OnValueChanged -= SwitchSoundSettings;
        }
    }
}