using Godot;

namespace Code.Projects.Config;

public class ProjectConfig : IProjectConfig
{
  public string Name => ProjectSettings.GetSetting("application/config/name", "Unknown").AsString();
  
  public string Version => ProjectSettings.GetSetting("application/config/version", "0").AsString();
}