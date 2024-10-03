using Code.Audio.Factories;
using Code.Audio.Services;
using Code.Common.Curtains;
using Code.Common.Extensions;
using Code.Common.View.Factories;
using Code.Credits.UI.About;
using Code.Gameplay.Cameras.Factories;
using Code.Gameplay.Character.Factories;
using Code.Gameplay.HUD;
using Code.Gameplay.Windows.MenuWindow;
using Code.Home.UI.MainMenu;
using Code.Infrastructure.EntityFactories;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Instantioator;
using Code.Infrastructure.LifeTime;
using Code.Infrastructure.Physics;
using Code.Infrastructure.Randoms;
using Code.Infrastructure.ResourceManagement;
using Code.Infrastructure.SceneManagement;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Resolvers;
using Code.Infrastructure.Systems;
using Code.Infrastructure.Time;
using Code.Infrastructure.UI;
using Code.Infrastructure.UI.Windows.Factories;
using Code.Infrastructure.UI.Windows.Services;
using Code.Levels.Services;
using Code.Levels.UI.Factories;
using Code.Levels.UI.LevelsButton;
using Code.Levels.UI.LevelsMenu;
using Code.PersistentData;
using Code.PersistentData.SaveLoad;
using Code.Projects.EntryPoint;
using Code.Projects.Providers.Curtains;
using Code.Projects.Providers.Game;
using Code.Projects.Providers.Root;
using Code.Projects.Providers.Scenes;
using Code.Projects.Settings;
using Code.SettingsWindow;
using Code.StaticData;
using Ninject.Modules;
using Ninject.Syntax;

namespace Code.Projects.Modules
{
  public class ProjectModule : NinjectModule
  {
    public override void Load()
    {
      BindProviders(this);
      
      BindContexts(this);
      
      BindCommonFactories(this);
      BindCommonServices(this);
      
      BindStateMachine(this);

      BindUiViewPresenters(this);
      BindUiFactories(this);

      BindGameplayServices(this);
      BindGameplayFactories(this);
    }

    private static void BindProviders(ProjectModule binder)
    {
      binder.BindInterfacesAndSelfTo<RootProvider>().InSingletonScope();
      binder.BindInterfacesAndSelfTo<SceneRootProvider>().InSingletonScope();
      binder.BindInterfacesAndSelfTo<CurtainNodeProvider>().InSingletonScope();
      binder.BindInterfacesAndSelfTo<GameRootProvider>().InSingletonScope();
    }

    private static void BindContexts(IBindingRoot binder)
    {
      binder.Bind<GameContext>().ToConstant(Contexts.sharedInstance.game);
      binder.Bind<InputContext>().ToConstant(Contexts.sharedInstance.input);
      binder.Bind<MetaContext>().ToConstant(Contexts.sharedInstance.meta);
    }

    private static void BindStateMachine(IBindingRoot binder)
    {
      binder.Bind<IStateResolver>().To<StateResolver>().InSingletonScope();
      binder.BindInterfacesTo<StateMachine>().InSingletonScope();
    }

    private void BindCommonServices(IBindingRoot binder)
    {
      binder.Bind<IProjectSettings>().To<ProjectSettings>().InSingletonScope();
      binder.Bind<ILifeTime>().To<LifeTime>().InSingletonScope();
      
      binder.BindInterfacesTo<ProjectEntryPoint>().InSingletonScope();
      
      binder.Bind<IStaticDataService>().To<StaticDataService>().InSingletonScope();
      
      binder.Bind<IPersistentDataProvider>().To<PersistentDataProvider>().InSingletonScope();
      binder.Bind<ISaveLoadService>().To<SaveLoadService>().InSingletonScope();

      binder.Bind<IIdProvider>().To<IdProvider>().InSingletonScope();
      binder.BindInterfacesTo<TimeService>().InSingletonScope();
      binder.Bind<ICurtainService>().To<CurtainService>().InSingletonScope();
      
      binder.Bind<IRandomService>().To<SimpleRandomService>().InSingletonScope();
      
      binder.Bind<ISceneLoader>().To<SceneLoader>().InSingletonScope();
      binder.Bind<IResourcesProvider>().To<ResourcesProvider>().InSingletonScope();
      
      binder.Bind<IAudioService>().To<AudioService>().InSingletonScope();
      
      binder.BindInterfacesTo<ColliderToEntityRegistryResolver>().InSingletonScope();

      // builder.Register<ColliderToEntityRegistryResolver>(Lifetime.Singleton).AsImplementedInterfaces();
      // builder.Register<UnityPhysicsService>(Lifetime.Singleton).As<IPhysicsService>();
      
      binder.Bind<IWindowService>().To<WindowService>().InSingletonScope();
    }

    private static void BindCommonFactories(IBindingRoot binder)
    {
      binder.Bind<IInstantiator>().To<Instantiator>().InSingletonScope();
    
      binder.Bind<IEntityViewPool>().To<EntityViewPool>().InSingletonScope();
      binder.Bind<IEntityViewFactory>().To<EntityViewFactory>().InSingletonScope();
      binder.Bind<IEntityFactory>().To<EntityFactory>().InSingletonScope();
      
      binder.Bind<ISystemFactory>().To<SystemFactory>().InSingletonScope();
      
      binder.Bind<IWindowFactory>().To<WindowFactory>().InSingletonScope();
      
      binder.Bind<IAudioPlayerFactory>().To<AudioPlayerFactory>().InSingletonScope();
      
    }
    
    private static void BindUiFactories(IBindingRoot binder)
    {
      binder.Bind<ILevelButtonFactory>().To<LevelButtonFactory>().InSingletonScope();
    }
    
    private static void BindUiViewPresenters(IBindingRoot binder)
    {
      binder.Bind<IPresenterResolver>().To<PresenterResolver>().InSingletonScope();
      
      binder.BindInterfacesTo<MainMenuUiPresenter>().InSingletonScope();
      
      binder.BindInterfacesTo<LevelsMenuUiPresenter>().InSingletonScope();
      binder.BindInterfacesTo<LevelButtonUiPresenter>().InSingletonScope();
         
      binder.BindInterfacesTo<AboutUiPresenter>().InSingletonScope();
      
      binder.BindInterfacesTo<SettingsWindowPresenter>().InSingletonScope();
      binder.BindInterfacesTo<GameMenuWindowPresenter>().InSingletonScope();
      
      binder.BindInterfacesTo<GameHUDPresenter>().InSingletonScope();
    }
    //
    // private static void RegisterUIViewServices(IContainerBuilder builder)
    // {
    //   builder.Register<SettingsUIService>(Lifetime.Singleton).AsImplementedInterfaces();
    // }
    //
    private static void BindGameplayServices(IBindingRoot binder)
    {
      binder.Bind<ILevelDataProvider>().To<LevelDataProvider>().InSingletonScope();
      // builder.Register<SimpleInputService>(Lifetime.Singleton).As<IInputService>();
    }
    
    private static void BindGameplayFactories(IBindingRoot binder)
    {
      binder.Bind<ICharacterFactory>().To<CharacterFactory>().InSingletonScope();
      binder.Bind<ICameraFactory>().To<CameraFactory>().InSingletonScope();
    }
  }
}