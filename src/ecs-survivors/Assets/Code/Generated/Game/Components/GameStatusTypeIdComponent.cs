//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherStatusTypeId;

    public static Entitas.IMatcher<GameEntity> StatusTypeId {
        get {
            if (_matcherStatusTypeId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StatusTypeId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStatusTypeId = matcher;
            }

            return _matcherStatusTypeId;
        }
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
public partial class GameEntity {

    public Code.Gameplay.Features.Statuses.StatusComponents.StatusTypeIdComponent statusTypeId { get { return (Code.Gameplay.Features.Statuses.StatusComponents.StatusTypeIdComponent)GetComponent(GameComponentsLookup.StatusTypeId); } }
    public Code.Gameplay.Features.Statuses.StatusTypeId StatusTypeId { get { return statusTypeId.Value; } }
    public bool hasStatusTypeId { get { return HasComponent(GameComponentsLookup.StatusTypeId); } }

    public GameEntity AddStatusTypeId(Code.Gameplay.Features.Statuses.StatusTypeId newValue) {
        var index = GameComponentsLookup.StatusTypeId;
        var component = (Code.Gameplay.Features.Statuses.StatusComponents.StatusTypeIdComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Statuses.StatusComponents.StatusTypeIdComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceStatusTypeId(Code.Gameplay.Features.Statuses.StatusTypeId newValue) {
        var index = GameComponentsLookup.StatusTypeId;
        var component = (Code.Gameplay.Features.Statuses.StatusComponents.StatusTypeIdComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Statuses.StatusComponents.StatusTypeIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveStatusTypeId() {
        RemoveComponent(GameComponentsLookup.StatusTypeId);
        return this;
    }
}
