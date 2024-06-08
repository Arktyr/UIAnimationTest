using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Game.Animations.Window
{
    public class WindowAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform _window;
        [SerializeField] private RectTransform _canvas;
        [SerializeField] private CanvasGroup _alpha;
        
        [SerializeField] private int _durationInSeconds;
        
        [SerializeField] private float _durationInSecondsFadeShow;
        [SerializeField] private float _durationInSecondsFadeHide;

        [SerializeField] private Ease _ease;
        
        
        private Vector2 _startPosition;
        private Vector2 _offscreenDownPosition;

        private void Awake()
        {
            _startPosition = _window.anchoredPosition;
        }

        public async Task ShowWindow()
        {
            Vector2 offscreenTopPosition = new Vector2(_startPosition.x, _canvas.rect.height);
            
            DoFadeWindow(1, 0, _durationInSecondsFadeShow);
            DoMoveWindow(_startPosition, offscreenTopPosition);
            
            await Task.Delay(_durationInSeconds * 1000);
        }

        public async Task HideWindow()
        {
            Vector2 offscreenDownPosition = new Vector2(_startPosition.x, -_canvas.rect.height);
            
            DoFadeWindow(0, 1, _durationInSecondsFadeHide);
            DoMoveWindow(offscreenDownPosition, _startPosition);
            
            await Task.Delay(_durationInSeconds * 1000);
        }

        private void DoMoveWindow(Vector2 offscreenPosition, Vector2 fromPosition)
        {
            _window
                .DOAnchorPos(offscreenPosition, _durationInSeconds)
                .From(fromPosition)
                .SetEase(_ease);
        }

        private void DoFadeWindow(float value, float fromValue, float duration)
        {
            _alpha
                .DOFade(value, duration)
                .From(fromValue)
                .SetEase(_ease);
        }
    }
}