using System.Threading.Tasks;
using _Scripts.Infrastructure.Singleton;

namespace _Scripts.Infrastructure.Scene
{
    public interface ISceneLoaderService : IService
    {
        Task LoadSceneAsync(SceneID sceneID);
    }
}