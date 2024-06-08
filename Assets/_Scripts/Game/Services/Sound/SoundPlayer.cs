using _Scripts.Game.Services.Settings;
using _Scripts.Infrastructure.Installer;
using _Scripts.Infrastructure.Singleton;

namespace _Scripts.Game.Services.Sound
{
    public class SoundPlayer : IInjectable
    {
        private ISoundService _soundService;
        
        public override void Inject() => 
            _soundService = AllServices.Container.GetSingle<ISoundService>();

        public void PlaySound(SoundID soundID) => 
            _soundService.PlayerSoundOneShot(soundID, SoundGroupID.Sounds);
    }
}