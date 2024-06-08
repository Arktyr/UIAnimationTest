using _Scripts.Infrastructure.Scene;
using _Scripts.Infrastructure.Singleton;
using _Scripts.UI.Windows;

namespace _Scripts.Infrastructure.Installer
{
    public class ProjectInstaller : Installer
    {
        public override void Install()
        {
            BindServices();
        }

        private void BindServices()
        {
            IWindowService windowService = AllServices.Container
                .RegisterSingle<IWindowService>(new WindowService());

            ISceneLoaderService sceneLoaderService = AllServices.Container
                .RegisterSingle<ISceneLoaderService>(new SceneLoaderService());
        }
    }
}