using System;

namespace Code.Projects.Settings;

public class ProjectSettings : IProjectSettings
{
  private const string OverrideSettingsPath = "override.cfg";
  private const string EffectVolumeKey = "audio/effect/volume";
  private const string MusicVolumeKey = "audio/music/volume";
  private const string GeneralVolumeKey = "audio/general/volume";
  private const string ApplicationNameKey = "application/config/name";
  private const string ApplicationVersionKey = "application/config/version";

  public string Name => Godot.ProjectSettings.GetSetting(ApplicationNameKey, "Unknown").AsString();
  
  public string Version => Godot.ProjectSettings.GetSetting(ApplicationVersionKey, "0").AsString();
  
  public float GeneralVolume
  {
    get => Godot.ProjectSettings.HasSetting(GeneralVolumeKey) 
      ? (float)Godot.ProjectSettings.GetSetting(GeneralVolumeKey, 1f).AsDouble()
      : 1f;
    set => Godot.ProjectSettings.SetSetting(GeneralVolumeKey, Math.Clamp(value, 0, 1));
  }
  
  public float MusicVolume
  {
    get => Godot.ProjectSettings.HasSetting(MusicVolumeKey) 
      ? (float)Godot.ProjectSettings.GetSetting(MusicVolumeKey, 1f).AsDouble()
      : 1f;
    set => Godot.ProjectSettings.SetSetting(MusicVolumeKey, Math.Clamp(value, 0, 1));
  }
  
  public float EffectVolume
  {
    get => Godot.ProjectSettings.HasSetting(EffectVolumeKey) 
      ? (float)Godot.ProjectSettings.GetSetting(EffectVolumeKey, 1f).AsDouble()
      : 1f;
    set => Godot.ProjectSettings.SetSetting(EffectVolumeKey, Math.Clamp(value, 0, 1));
  }

  public void Save() => Godot.ProjectSettings.SaveCustom(OverrideSettingsPath);
}