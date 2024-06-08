using System.Threading.Tasks;
using _Scripts.Extensions;
using _Scripts.Infrastructure.Singleton;
using UnityEngine;

namespace _Scripts.Game.UI.Curtain
{
    public class CurtainPresenter : MonoBehaviour, IService
    {
        [SerializeField] private CurtainView _curtainView;

        public async Task ShowCurtain()
        {
            await AsyncOpertions.GetAwaitBool((() => _curtainView.IsInAnimation == false));
            
            await _curtainView.Enable();
        }

        public async Task DisableCurtain()
        {
            await AsyncOpertions.GetAwaitBool((() => _curtainView.IsInAnimation == false));
            
            await _curtainView.Disable();
        }
    }
}