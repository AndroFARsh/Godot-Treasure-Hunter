using Code.PersistentData.Data;

namespace Code.PersistentData;

public interface IPersistentDataProvider
{
  ProgressData ProgressData { get; }

  void SetProgressData(ProgressData data);
}