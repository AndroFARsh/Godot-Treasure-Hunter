//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherViewPrefab;

    public static Entitas.IMatcher<InputEntity> ViewPrefab {
        get {
            if (_matcherViewPrefab == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.ViewPrefab);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherViewPrefab = matcher;
            }

            return _matcherViewPrefab;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by KSyndicate.CustomGenerators.Plugins.SingleValueComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity : IViewPrefabEntity<InputEntity>, IViewPrefabEntity
{
    Entitas.IEntity IViewPrefabEntity<Entitas.IEntity>.AddViewPrefab(Godot.PackedScene newValue)
    {
        return AddViewPrefab(newValue);
    }

    Entitas.IEntity IViewPrefabEntity<Entitas.IEntity>.ReplaceViewPrefab(Godot.PackedScene newValue)
    {
        return ReplaceViewPrefab(newValue);
    }

    Entitas.IEntity IViewPrefabEntity<Entitas.IEntity>.RemoveViewPrefab()
    {
        return RemoveViewPrefab();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public Code.Common.ViewPrefabComponent viewPrefab { get { return (Code.Common.ViewPrefabComponent)GetComponent(InputComponentsLookup.ViewPrefab); } }
    public Godot.PackedScene ViewPrefab { get { return viewPrefab.Value; } }
    public bool hasViewPrefab { get { return HasComponent(InputComponentsLookup.ViewPrefab); } }

    public InputEntity AddViewPrefab(Godot.PackedScene newValue) {
        var index = InputComponentsLookup.ViewPrefab;
        var component = (Code.Common.ViewPrefabComponent)CreateComponent(index, typeof(Code.Common.ViewPrefabComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public InputEntity ReplaceViewPrefab(Godot.PackedScene newValue) {
        var index = InputComponentsLookup.ViewPrefab;
        var component = (Code.Common.ViewPrefabComponent)CreateComponent(index, typeof(Code.Common.ViewPrefabComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public InputEntity RemoveViewPrefab() {
        RemoveComponent(InputComponentsLookup.ViewPrefab);
        return this;
    }
}
