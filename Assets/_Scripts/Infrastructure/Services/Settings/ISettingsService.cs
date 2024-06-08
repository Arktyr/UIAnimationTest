using _Scripts.Infrastructure.Singleton;

namespace _Scripts.Game.Services.Settings
{
    public interface ISettingsService : IService
    {
        void SetSoundsVolume(SoundGroupID soundGroupID, float value);
        void UpdateData();
    }
}