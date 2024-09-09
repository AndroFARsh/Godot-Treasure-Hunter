using Entitas;
using Godot;

namespace Code.Home.Systems
{
  public class PlayHomeMusicSystem : IInitializeSystem, ITearDownSystem
  {
    // private readonly ISoundService _soundService;

    public PlayHomeMusicSystem()//(ISoundService soundService)
    {
      // _soundService = soundService;
    }

    public void Initialize()
    {
      GD.Print("INit");
    }
    // => _soundService.PlayMusic(MusicName.HomeThem);

    public void TearDown()
    {
      GD.Print("TearDown");
    }
    // => _soundService.StopMusic(MusicName.HomeThem);
  }
}