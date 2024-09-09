//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherId;

    public static Entitas.IMatcher<InputEntity> Id {
        get {
            if (_matcherId == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Id);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherId = matcher;
            }

            return _matcherId;
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
public partial class InputEntity : IIdEntity<InputEntity>, IIdEntity
{
    Entitas.IEntity IIdEntity<Entitas.IEntity>.AddId(ulong newValue)
    {
        return AddId(newValue);
    }

    Entitas.IEntity IIdEntity<Entitas.IEntity>.ReplaceId(ulong newValue)
    {
        return ReplaceId(newValue);
    }

    Entitas.IEntity IIdEntity<Entitas.IEntity>.RemoveId()
    {
        return RemoveId();
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

    public Code.Common.IdComponent id { get { return (Code.Common.IdComponent)GetComponent(InputComponentsLookup.Id); } }
    public ulong Id { get { return id.Value; } }
    public bool hasId { get { return HasComponent(InputComponentsLookup.Id); } }

    public InputEntity AddId(ulong newValue) {
        var index = InputComponentsLookup.Id;
        var component = (Code.Common.IdComponent)CreateComponent(index, typeof(Code.Common.IdComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public InputEntity ReplaceId(ulong newValue) {
        var index = InputComponentsLookup.Id;
        var component = (Code.Common.IdComponent)CreateComponent(index, typeof(Code.Common.IdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public InputEntity RemoveId() {
        RemoveComponent(InputComponentsLookup.Id);
        return this;
    }
}
