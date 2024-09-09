using Code.Infrastructure.PersistentData.Data;

namespace Code.Infrastructure.PersistentData
{
  public class PersistentDataProvider : IPersistentDataProvider
  {
    public SettingsData SettingsData { get; private set; }
    public ProgressData ProgressData { get; private set; }

    public void SetProgressData(ProgressData data)
    {
      ProgressData = data;
    }

    public void SetSettingsData(SettingsData data)
    {
      SettingsData = data;
    }
  }
}