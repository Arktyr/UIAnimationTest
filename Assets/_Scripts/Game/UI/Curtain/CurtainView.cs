using System.Threading.Tasks;
using _Scripts.Game.Animations.Window.Common;
using UnityEngine;

namespace _Scripts.Game.UI.Curtain
{
    public class CurtainView : MonoBehaviour
    {
        [SerializeField] private FadeUIAnimation _fadeUIAnimation;
        
        public async Task Enable()
        {
            gameObject.SetActive(true);
            await _fadeUIAnimation.DoFadeIn();
        }

        public async Task Disable()
        {
            await _fadeUIAnimation.DoFadeOut();
            gameObject.SetActive(false);
        }
    }
}