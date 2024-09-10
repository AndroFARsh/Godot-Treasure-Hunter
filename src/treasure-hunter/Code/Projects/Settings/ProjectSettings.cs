using System;

namespace Code.Projects.Settings;

public class ProjectSettings : IProjectSettings
{
  public string Name => Godot.ProjectSettings.GetSetting("application/config/name", "Unknown").AsString();
  
  public string Version => Godot.ProjectSettings.GetSetting("application/config/version", "0").AsString();

  public float MusicVolume
  {
    get => (float)Godot.ProjectSettings.GetSetting("audio/music/volume", 1f).AsDouble();
    set => Godot.ProjectSettings.SetSetting("audio/music/volume", Math.Clamp(value, 0, 1));
  }
  
  public float EffectVolume
  {
    get => (float)Godot.ProjectSettings.GetSetting("audio/audio-effect/volume", 1f).AsDouble();
    set => Godot.ProjectSettings.SetSetting("audio/audio-effect/volume", Math.Clamp(value, 0, 1));
  }

  public void Save() => Godot.ProjectSettings.SaveCustom("override.cfg");
}