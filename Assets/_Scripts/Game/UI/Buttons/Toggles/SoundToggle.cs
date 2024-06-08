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
        [SerializeField] private SoundPlayer _soundPlayer;
        [SerializeField] private SoundID _soundID;
        [SerializeField] private float _valueOn;
        [SerializeField] private float _valueOff;

        public event Action<float, SoundGroupID> OnValueChanged;

        private void Awake()
        {
            UpdateData();
            _toggle.onValueChanged.AddListener(OnToggleClicked);
        }

        private void OnToggleClicked(bool flag)
        {
            _soundPlayer.PlaySound(_soundID);
            
            if (flag)
            {
                OnValueChanged?.Invoke(_valueOn, _soundGroupID);
                PlayerPrefs.SetFloat(_soundGroupID.ToString(), _valueOn);
                PlayerPrefs.SetString(_soundGroupID.ToString(), "true");

                return;
            }
            
            OnValueChanged?.Invoke(_valueOff, _soundGroupID);
            PlayerPrefs.SetFloat(_soundGroupID.ToString(), _valueOff);
            PlayerPrefs.SetString(_soundGroupID.ToString(), "false");
        }


        private void UpdateData()
        {
            string flag = PlayerPrefs.GetString(_soundGroupID.ToString());
            
            switch (flag)
            {
                case "false":
                    _toggle.isOn = false;
                    return;
                default:
                    _toggle.isOn = true;
                    break;
            }
        }
    }
}