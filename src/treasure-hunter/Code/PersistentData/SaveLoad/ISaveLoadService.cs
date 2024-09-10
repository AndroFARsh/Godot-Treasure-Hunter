namespace Code.PersistentData.SaveLoad
{
  public interface ISaveLoadService
  {
    void InitializePersistentData();
    
    void LoadPersistentData();
    
    void SavePersistentData();
  }
}