using _Scripts.Infrastructure.Singleton;

namespace _Scripts.Infrastructure.Services.Settings
{
    public interface ISettingsService : IService
    {
        void SetSoundsVolume(SoundGroupID soundGroupID, float value);
        void UpdateData();
    }
}