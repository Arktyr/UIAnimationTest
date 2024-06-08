using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Game.Animations.Window.Common
{
    public class FadeUIAnimation : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _alpha;
        [SerializeField] private Ease _ease;
        
        [SerializeField] private float _durationInSecondsIn;
        [SerializeField] private float _durationInSecondsOut;

        private Tween _currentTween; 
        
        public void DoFadeIn()
        {
            _currentTween?.Kill();
            
            _currentTween = _alpha
                .DOFade(1, _durationInSecondsIn)
                .From(0)
                .SetEase(_ease);
        }

        public void DoFadeOut()
        {
            _currentTween?.Kill();
            
            _currentTween = _alpha
                .DOFade(0, _durationInSecondsOut)
                .From(1)
                .SetEase(_ease);
        }

        public void StopTween() => 
            _currentTween?.Kill();
    }
}