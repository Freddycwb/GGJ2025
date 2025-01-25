using UnityEngine;

public class SetColliderWithGrower : MonoBehaviour
{
	[SerializeField] private Grower grower;
	[SerializeField] private CircleCollider2D col;

	public void OnStageChanged() {
		col.radius = (grower.stage + 1)/2.0f;
	}
}
