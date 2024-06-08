using System;
using _Scripts.Game.Services.Settings;
using _Scripts.Game.Services.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Game.UI.Buttons.Toggles
{
    public class SoundToggle : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;
        [SerializeField] private SoundGroupID _soundGroupID;
        [SerializeField] private float _valueOn;
        [SerializeField] private float _valueOff;

        public event Action<float, SoundGroupID> OnValueChanged; 

        private void Awake() => 
            _toggle.onValueChanged.AddListener(OnToggleClicked);

        private void OnToggleClicked(bool flag)
        {
            if (flag)
            {
                OnValueChanged?.Invoke(_valueOn, _soundGroupID);
                return;
            }
            
            OnValueChanged?.Invoke(_valueOff, _soundGroupID);
        }


        public void UpdateData(bool data)
        {
            _toggle.isOn = data;
        }
    }
}