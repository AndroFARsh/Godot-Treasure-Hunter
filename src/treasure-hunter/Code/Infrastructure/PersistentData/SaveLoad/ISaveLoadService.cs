namespace Code.Infrastructure.PersistentData.SaveLoad
{
  public interface ISaveLoadService
  {
    void InitializePersistentData();
    void InitializeProgressData();
    void InitializeSettingsData();
    void SaveSettings();
    void SaveProgress();
  }
}