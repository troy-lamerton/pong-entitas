using Entitas;
using UnityEngine;

[Game]
public sealed class LimitPositionComponent : IComponent {

	public Vector2 min;
	public Vector2 max;
}
