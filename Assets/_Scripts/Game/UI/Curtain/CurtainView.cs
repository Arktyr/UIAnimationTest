using System.Threading.Tasks;
using _Scripts.Game.Animations.Window.Common;
using UnityEngine;

namespace _Scripts.Game.UI.Curtain
{
    public class CurtainView : MonoBehaviour
    {
        [SerializeField] private FadeUIAnimation _fadeUIAnimation;

        [SerializeField] private int _delayInSeconds;
        public bool IsInAnimation { get; private set; }
        
        public async Task Enable()
        {
            gameObject.SetActive(true);
            
            IsInAnimation = true;
            _fadeUIAnimation.DoFadeIn();
            await Task.Delay(_delayInSeconds * 1000);
            IsInAnimation = false;
        }

        public async Task Disable()
        {
            IsInAnimation = true;
            _fadeUIAnimation.DoFadeOut();
            await Task.Delay(_delayInSeconds * 1000);
            IsInAnimation = false;
            
            gameObject.SetActive(false);
        }
    }
}