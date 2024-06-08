using _Scripts.Game.Services.Windows;
using _Scripts.Game.Services.Windows.Switch;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Game.UI.Buttons.Window
{
    public class SwitchWindowButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private WindowID _windowID;
        [SerializeField] private WindowSwitcher _windowSwitcher;

        private void Awake() => 
            _button.onClick.AddListener(SwitchWindow);

        private void SwitchWindow() => 
            _windowSwitcher.SwitchWindow(_windowID);

        private void OnDestroy() => 
            _button.onClick.RemoveAllListeners();
    }
}