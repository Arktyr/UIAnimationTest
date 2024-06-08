using System;
using _Scripts.Game.Animations.Window.Common;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Game.Animations.Window
{
    public class WindowAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform _window;
        [SerializeField] private RectTransform _canvas;
        
        [SerializeField] private int _durationInSeconds;

        [SerializeField] private FadeUIAnimation _fadeUIAnimation;

        [SerializeField] private Ease _ease;

        private Vector2 _startPosition;
        private Vector2 _offscreenDownPosition;

        private Tween _moveTween;

        private Action _currentAction;
        
        private void Awake()
        {
            _startPosition = _window.anchoredPosition;
        }

        public void ShowWindow(Action onComplete)
        {
            StopAnimation();
            _currentAction = onComplete;
            Vector2 offscreenTopPosition = new Vector2(_startPosition.x, _canvas.rect.height);
            
            _fadeUIAnimation.DoFadeIn();
            DoMoveWindow(_startPosition, offscreenTopPosition);
        }

        public void HideWindow(Action onComplete)
        {
            StopAnimation();
            _currentAction = onComplete;
            Vector2 offscreenDownPosition = new Vector2(_startPosition.x, -_canvas.rect.height);
            
            _fadeUIAnimation.DoFadeOut();
            DoMoveWindow(offscreenDownPosition, _startPosition);
        }

        private void DoMoveWindow(Vector2 offscreenPosition, Vector2 fromPosition)
        {
            _moveTween = _window
                .DOAnchorPos(offscreenPosition, _durationInSeconds)
                .From(fromPosition)
                .SetEase(_ease)
                .OnComplete(() => _currentAction?.Invoke());
        }

        private void StopAnimation()
        {
            _moveTween?.Kill();
            _fadeUIAnimation.StopTween();
        }
    }
}