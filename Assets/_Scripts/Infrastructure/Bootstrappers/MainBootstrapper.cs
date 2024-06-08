using _Scripts.Game.UI.Windows.Settings;
using _Scripts.Infrastructure.Installer;
using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.App.States;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Infrastructure.StateMachines.App
{
    public class MainBootstrapper : IInjectable
    {
       [SerializeField] private SettingsWindow _settingsWindow;

        private MainState _mainState;

        public override void Inject()
        {
            _mainState = AllServices.Container.GetSingle<MainState>();

            _mainState.SetLocalDependencies(_settingsWindow);
            
            Debug.Log(_settingsWindow);
        }
    }
}