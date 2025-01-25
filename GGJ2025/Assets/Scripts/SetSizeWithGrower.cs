using UnityEngine;

public class SetSizeWithGrower : MonoBehaviour
{
	[SerializeField] private Grower grower;

	public void OnStageChanged() {
		transform.localScale = new Vector2(1 + grower.stage * grower.growAmount, 1 + grower.stage * grower.growAmount);
	}
}
