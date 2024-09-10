using Code.Audio;
using Code.Audio.Services;
using Code.Common.Curtains;
using Code.Infrastructure.States.Infrastructure;
using GodotTask;

namespace Code.Projects.States;

public class LevelsState : NoPayloadState
{
  private readonly ICurtainService _curtainService;
  private readonly IAudioService _audioService;

  public LevelsState(
    ICurtainService curtainService,
    IAudioService audioService)
  {
    _curtainService = curtainService;
    _audioService = audioService;
  }

  protected override void OnEnter()
  {
    _audioService.PlayMusic(MusicName.HomeTheme);
    _curtainService.HideCurtain().Forget();
  }

  protected override async GDTask OnExitAsync()
  {
    await _curtainService.ShowCurtain();
  }
}