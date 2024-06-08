using _Scripts.Game.Services.Settings;
using _Scripts.Game.UI.Curtain;
using _Scripts.Infrastructure.Scene;
using _Scripts.Infrastructure.Singleton;
using _Scripts.UI.Windows;
using UnityEngine;

namespace _Scripts.Infrastructure.Installer
{
    public class ProjectInstaller : Installer
    {
        [SerializeField] private SettingsService _settingsService;
        [SerializeField] private CurtainPresenter _curtain;
        
        public override void Install()
        {
            BindServices();
            BindUI();
        }

        private void BindServices()
        {
            IWindowService windowService = AllServices.Container
                .RegisterSingle<IWindowService>(new WindowService());

            ISceneLoaderService sceneLoaderService = AllServices.Container
                .RegisterSingle<ISceneLoaderService>(new SceneLoaderService());

            ISettingsService settingsService = AllServices.Container
                .RegisterSingle<ISettingsService>(_settingsService);
        }

        private void BindUI()
        {
            AllServices.Container
                .RegisterSingle(_curtain);
        }
    }
}