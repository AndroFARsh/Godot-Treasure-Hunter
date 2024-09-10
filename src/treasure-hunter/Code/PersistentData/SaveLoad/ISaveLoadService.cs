namespace Code.PersistentData.SaveLoad
{
  public interface ISaveLoadService
  {
    void Initialize();
    
    void LoadPersistentData();
    
    void SavePersistentData();
  }
}