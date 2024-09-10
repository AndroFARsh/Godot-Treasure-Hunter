using System;
using Godot;

namespace Code.Audio;

public enum AudioBus
{
  General = 0,
  Music = 1,
  Effect = 2
}
  
public static class AudioBusExtensions
{
  public static string AsName(this AudioBus value) =>
    AudioServer.GetBusName((int)value);

  public static int AsIndex(this AudioBus value) =>
    AudioServer.GetBusIndex(value.AsName());

  public static AudioBus ToAudioBus(this StringName value) =>
    (AudioBus)AudioServer.GetBusIndex(value);
}