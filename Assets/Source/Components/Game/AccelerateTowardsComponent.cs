using Entitas;
using UnityEngine;

[Game]
public class AccelerateTowardsComponent : IComponent {

	public string targetTag;
	public float activeRange;
}
