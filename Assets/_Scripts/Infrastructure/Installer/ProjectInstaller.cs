﻿using _Scripts.Game.Services.Sound;
using _Scripts.Game.Services.Windows.Main;
using _Scripts.Game.UI.Curtain;
using _Scripts.Infrastructure.Scene;
using _Scripts.Infrastructure.Services.Settings;
using _Scripts.Infrastructure.Services.Sound;
using _Scripts.Infrastructure.Singleton;
using UnityEngine;

namespace _Scripts.Infrastructure.Installer
{
    public class ProjectInstaller : Common.Installer
    {
        [SerializeField] private SettingsService _settingsService;
        [SerializeField] private SoundService _soundService;
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

            ISoundService soundService = AllServices.Container
                .RegisterSingle<ISoundService>(_soundService);
        }

        private void BindUI()
        {
            AllServices.Container
                .RegisterSingle(_curtain);
        }
    }
}