using System;
using _Scripts.Game.UI.Windows.Hello;
using _Scripts.Game.UI.Windows.Settings;
using _Scripts.Infrastructure.Installer;
using _Scripts.Infrastructure.Singleton;
using UnityEngine;

namespace _Scripts.UI.Windows.Switch
{
    public class WindowSwitcher : IInjectable
    {
        private IWindowService _windowService;

        public override void Inject()
        {
            _windowService = AllServices.Container.GetSingle<IWindowService>();
        }

        public void SwitchWindow(WindowID windowID)
        {
            switch (windowID)
            {
                case WindowID.HelloWindow:
                    _windowService.Open<HelloWindow>();
                    break;
                case WindowID.SettingsWindow:
                    _windowService.Open<SettingsWindow>();
                    break;
                default:
                    Debug.LogError($"{windowID}: This Window Not Found");
                    break;
            }
        }

        public void CloseWindow() => 
            _windowService.Close();
    }
}