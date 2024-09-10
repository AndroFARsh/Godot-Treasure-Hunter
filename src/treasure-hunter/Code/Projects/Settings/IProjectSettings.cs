namespace Code.Projects.Settings;

public interface IProjectSettings
{
  string Name { get; }
  string Version { get; }
  float MusicVolume { get; set; }
  float EffectVolume { get; set; }
  void Save();
}