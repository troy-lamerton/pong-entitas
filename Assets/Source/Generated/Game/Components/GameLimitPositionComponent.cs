//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LimitPositionComponent limitPosition { get { return (LimitPositionComponent)GetComponent(GameComponentsLookup.LimitPosition); } }
    public bool hasLimitPosition { get { return HasComponent(GameComponentsLookup.LimitPosition); } }

    public void AddLimitPosition(UnityEngine.Vector2 newMin, UnityEngine.Vector2 newMax) {
        var index = GameComponentsLookup.LimitPosition;
        var component = CreateComponent<LimitPositionComponent>(index);
        component.min = newMin;
        component.max = newMax;
        AddComponent(index, component);
    }

    public void ReplaceLimitPosition(UnityEngine.Vector2 newMin, UnityEngine.Vector2 newMax) {
        var index = GameComponentsLookup.LimitPosition;
        var component = CreateComponent<LimitPositionComponent>(index);
        component.min = newMin;
        component.max = newMax;
        ReplaceComponent(index, component);
    }

    public void RemoveLimitPosition() {
        RemoveComponent(GameComponentsLookup.LimitPosition);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLimitPosition;

    public static Entitas.IMatcher<GameEntity> LimitPosition {
        get {
            if(_matcherLimitPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LimitPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLimitPosition = matcher;
            }

            return _matcherLimitPosition;
        }
    }
}