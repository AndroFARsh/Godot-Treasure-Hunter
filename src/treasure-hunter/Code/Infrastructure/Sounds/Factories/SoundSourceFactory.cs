// using System.Collections.Generic;
// using Code.Infrastructure.StaticData;
// using TreasureHunter.Code.Infrastructure.Sounds.Factories;
// using UnityEngine;
// using VContainer;
// using VContainer.Unity;
//
// namespace Code.Infrastructure.Sounds.Factories
// {
//   public class SoundSourceFactory : ISoundSourceFactory
//   {
//     private readonly IObjectResolver _objectResolver;
//     private readonly IStaticDataService _staticDataService;
//     private readonly LinkedList<AudioSource> _fxSourcePool = new();
//
//     SoundSourceFactory(IObjectResolver objectResolver, IStaticDataService staticDataService)
//     {
//       _objectResolver = objectResolver;
//       _staticDataService = staticDataService;
//     }
//
//     public AudioSource PeekOrCreate()
//     {
//       AudioSource source;
//       if (_fxSourcePool.Count > 0)
//       {
//         source = _fxSourcePool.First.Value;
//         _fxSourcePool.RemoveFirst();
//         
//         source.gameObject.SetActive(true);
//       }
//       else
//       {
//         AudioSource prefab = _staticDataService.GetAudioSourcePrefab();
//         source = _objectResolver.Instantiate(prefab);
//       }
//
//       return source;
//     }
//
//     public void Release(AudioSource source)
//     {
//       source.clip = null;
//       source.gameObject.SetActive(false);
//       _fxSourcePool.AddLast(source);
//     }
//   }
// }