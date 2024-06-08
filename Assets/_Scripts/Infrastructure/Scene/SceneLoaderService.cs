using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Infrastructure.Scene
{
    public class SceneLoaderService : ISceneLoaderService
    {
        private const string STARTSCENENAME = "start";
        private const string MAINSCENENAME = "main";
        
        public async Task LoadSceneAsync(SceneID sceneID)
        {
            switch (sceneID)
            {
                case SceneID.StartScene:
                    await Load(STARTSCENENAME);
                    break;
                case SceneID.MainScene:
                    await Load(MAINSCENENAME);
                    break;
                default:
                    Debug.LogError($"{sceneID} : This Scene Not Found");
                    break;
            }
        }

        private async Task Load(string sceneName)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncOperation.isDone) 
                await Task.Yield();
        }
    }
}