using _Scripts.Game.Services.Settings;
using _Scripts.Infrastructure.Singleton;

namespace _Scripts.Game.Services.Sound
{
    public interface ISoundService : IService
    {
        void PlaySoundInLoop(SoundID soundID, SoundGroupID soundGroupID);
        void PlayerSoundOneShot(SoundID soundID, SoundGroupID soundGroupID);
    }
}