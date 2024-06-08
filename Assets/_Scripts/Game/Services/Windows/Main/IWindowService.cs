
using _Scripts.Infrastructure.Singleton;

namespace _Scripts.Game.Services.Windows.Main
{
    public interface IWindowService : IService 
    {
        void AddWindow(IWindow window);
        void RemoveWindow(IWindow window);
        void Open<TWindow>() where TWindow : IWindow;
        void Close();
        void ClearWindows();
    }
}