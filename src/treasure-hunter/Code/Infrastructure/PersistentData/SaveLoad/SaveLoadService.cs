using Code.Infrastructure.PersistentData.Data;

namespace Code.Infrastructure.PersistentData.SaveLoad
{
  public class SaveLoadService : ISaveLoadService
  {
    private const string ProgressKey = "Progress";
    private const string SettingsKey = "Settings";

    private readonly IPersistentDataProvider _persistentProvider;
    
    public SaveLoadService(IPersistentDataProvider persistentProvider)
    {
      _persistentProvider = persistentProvider;
    }

    public void InitializePersistentData()
    {
      InitializeSettingsData();
      InitializeProgressData();
    }
    
    public void SaveSettings()
    {
      //ProjectSettings.Sa
      // todo: save to prefs
      // PlayerPrefs.SetString(SettingsKey, _persistentProvider.SettingsData.ToJson());
      // PlayerPrefs.Save();
    }

    public void SaveProgress()
    {
      // todo: save to prefs
      // PlayerPrefs.SetString(ProgressKey, _persistentProvider.ProgressData.ToJson());
      // PlayerPrefs.Save();
    }

    public void InitializeProgressData() => 
      _persistentProvider.SetProgressData(new ProgressData());
      // _persistentProvider.SetProgressData(PlayerPrefs.HasKey(ProgressKey)
      //   ? PlayerPrefs.GetString(ProgressKey).FromJson<ProgressData>()
      //   : new ProgressData());

      public void InitializeSettingsData() =>
        _persistentProvider.SetSettingsData(new SettingsData());
      // _persistentProvider.SetSettingsData(PlayerPrefs.HasKey(SettingsKey)
      //   ? PlayerPrefs.GetString(SettingsKey).FromJson<SettingsData>()
      //   : new SettingsData());
  }
}