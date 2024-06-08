using System.Threading.Tasks;
using _Scripts.Game.Animations.Window.Common;
using UnityEngine;

namespace _Scripts.Game.UI.Curtain
{
    public class CurtainView : MonoBehaviour
    {
        [SerializeField] private FadeUIAnimation _fadeUIAnimation;

        public bool _isInAnimation;
        
        public async Task Enable()
        {
            gameObject.SetActive(true);
            
            _isInAnimation = true;
            await _fadeUIAnimation.DoFadeIn();
            _isInAnimation = false;
        }

        public async Task Disable()
        {
            _isInAnimation = true;
            await _fadeUIAnimation.DoFadeOut();
            _isInAnimation = false;
            
            gameObject.SetActive(false);
        }
    }
}