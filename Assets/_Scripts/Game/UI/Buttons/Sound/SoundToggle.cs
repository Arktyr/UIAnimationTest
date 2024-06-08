using _Scripts.Game.Services.Sound;
using _Scripts.Infrastructure.Services.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Game.UI.Buttons.Sound
{
    public class SoundToggle : MonoBehaviour
    {
        [SerializeField] private SoundPlayer _soundPlayer;
        [SerializeField] private SoundID _soundID;
        [SerializeField] private Toggle _toggle;
        
        private void Awake() => 
            _toggle.onValueChanged.AddListener(PlaySound);

        private void PlaySound(bool value) => 
            _soundPlayer.PlaySound(_soundID);

        private void OnDestroy() =>
            _toggle.onValueChanged.RemoveAllListeners();
    }
}