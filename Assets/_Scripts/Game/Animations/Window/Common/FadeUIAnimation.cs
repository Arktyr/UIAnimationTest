using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Game.Animations.Window.Common
{
    public class FadeUIAnimation : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _alpha;
        [SerializeField] private Ease _ease;
        [SerializeField] private int _durationInSeconds;

        private Tween _currentTween; 
        
        public async Task DoFadeIn()
        {
            _currentTween?.Kill();
            
            _currentTween = _alpha
                .DOFade(1, _durationInSeconds)
                .From(0)
                .SetEase(_ease);

            await Task.Delay(_durationInSeconds * 1000);
        }

        public async Task DoFadeOut()
        {
            _currentTween?.Kill();
            
            _currentTween = _alpha
                .DOFade(0, _durationInSeconds)
                .From(1)
                .SetEase(_ease);
            
            await Task.Delay(_durationInSeconds * 1000);
        }

        public void StopTween() => 
            _currentTween?.Kill();
    }
}