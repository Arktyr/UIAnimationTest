using _Scripts.Infrastructure.Services.Settings;
using _Scripts.Infrastructure.Singleton;

namespace _Scripts.Infrastructure.Services.Sound
{
    public interface ISoundService : IService
    {
        void PlaySoundInLoop(SoundID soundID, SoundGroupID soundGroupID);
        void PlayerSoundOneShot(SoundID soundID, SoundGroupID soundGroupID);
    }
}