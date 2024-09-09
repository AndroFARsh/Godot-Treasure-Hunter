using Code.Infrastructure.PersistentData.Data;

namespace Code.Infrastructure.PersistentData
{
  public interface IPersistentDataProvider
  {
    SettingsData SettingsData { get; }
    
    ProgressData ProgressData { get; }

    void SetProgressData(ProgressData data);
    
    void SetSettingsData(SettingsData data);
  }
}