using UnityEngine;
using Entitas;
using Entitas.CodeGenerator.Api;

[Input]
public class MovementComponent : IComponent {

	public Vector2 direction;
}
