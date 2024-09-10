using Code.PersistentData.Data;

namespace Code.PersistentData.SaveLoad
{
  public class SaveLoadService : ISaveLoadService
  {
    private const string ProgressKey = "Progress";

    private readonly IPersistentDataProvider _persistentProvider;

    public SaveLoadService(IPersistentDataProvider persistentProvider)
    {
      _persistentProvider = persistentProvider;
    }

    public void SaveProgress()
    {
      // todo: save to prefs
      // PlayerPrefs.SetString(ProgressKey, _persistentProvider.ProgressData.ToJson());
      // PlayerPrefs.Save();
    }

    public void InitializePersistentData() =>
      _persistentProvider.SetProgressData(new ProgressData());
    // _persistentProvider.SetProgressData(PlayerPrefs.HasKey(ProgressKey)
    //   ? PlayerPrefs.GetString(ProgressKey).FromJson<ProgressData>()
    //   : new ProgressData());


    public void LoadPersistentData()
    {
      throw new System.NotImplementedException();
    }

    public void SavePersistentData()
    {
      throw new System.NotImplementedException();
    }
  }
}