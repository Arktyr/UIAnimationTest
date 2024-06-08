using System.Threading.Tasks;
using _Scripts.Infrastructure.Singleton;
using UnityEngine;

namespace _Scripts.Game.UI.Curtain
{
    public class CurtainPresenter : MonoBehaviour, IService
    {
        [SerializeField] private CurtainView _curtainView;

        public async Task ShowCurtain() => 
            await _curtainView.Enable();

        public async Task DisableCurtain() => 
            await _curtainView.Disable();
    }
}