using _Scripts.Game.Services.Sound;
using _Scripts.Game.Services.States;
using _Scripts.Infrastructure.StateMachines.Common.States;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Game.UI.Buttons
{
    public class SwitchStateButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private StateID _stateID;
        [SerializeField] private StateSwitcher _stateSwitcher;
        
        private void Awake() => 
            _button.onClick.AddListener(SwitchWindow);

        private void SwitchWindow() => 
            _stateSwitcher.SwitchState(_stateID);

        private void OnDestroy() => 
            _button.onClick.RemoveAllListeners();
    }
}