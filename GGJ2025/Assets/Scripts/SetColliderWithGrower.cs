using UnityEngine;

public class SetColliderWithGrower : MonoBehaviour
{
	[SerializeField] private Grower grower;
	[SerializeField] private CircleCollider2D col;

	public void OnStageChanged() {
		col.radius = 0.5f + grower.stage * grower.growAmount/2;
	}
}
