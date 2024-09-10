using Code.PersistentData.Data;

namespace Code.PersistentData;

public class PersistentDataProvider : IPersistentDataProvider
{
  public ProgressData ProgressData { get; private set; }

  public void SetProgressData(ProgressData data)
  {
    ProgressData = data;
  }
}