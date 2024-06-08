using _Scripts.Game.Services.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Game.UI.Buttons.Sound
{
    public class SoundButton : MonoBehaviour
    {
        [SerializeField] private SoundPlayer _soundPlayer;
        [SerializeField] private SoundID _soundID;
        [SerializeField] private Button _button;
        
        private void Awake() => 
            _button.onClick.AddListener(PlaySound);

        private void PlaySound() => 
            _soundPlayer.PlaySound(_soundID);

        private void OnDestroy() => 
            _button.onClick.RemoveAllListeners();
    }
}