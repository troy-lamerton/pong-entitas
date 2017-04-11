//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MoveComponent move { get { return (MoveComponent)GetComponent(GameComponentsLookup.Move); } }
    public bool hasMove { get { return HasComponent(GameComponentsLookup.Move); } }

    public void AddMove(float newSpeed, float newMaxSpeed) {
        var index = GameComponentsLookup.Move;
        var component = CreateComponent<MoveComponent>(index);
        component.speed = newSpeed;
        component.maxSpeed = newMaxSpeed;
        AddComponent(index, component);
    }

    public void ReplaceMove(float newSpeed, float newMaxSpeed) {
        var index = GameComponentsLookup.Move;
        var component = CreateComponent<MoveComponent>(index);
        component.speed = newSpeed;
        component.maxSpeed = newMaxSpeed;
        ReplaceComponent(index, component);
    }

    public void RemoveMove() {
        RemoveComponent(GameComponentsLookup.Move);
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

    static Entitas.IMatcher<GameEntity> _matcherMove;

    public static Entitas.IMatcher<GameEntity> Move {
        get {
            if(_matcherMove == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Move);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMove = matcher;
            }

            return _matcherMove;
        }
    }
}