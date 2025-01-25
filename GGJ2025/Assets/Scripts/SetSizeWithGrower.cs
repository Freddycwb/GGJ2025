using UnityEngine;

public class SetSizeWithGrower : MonoBehaviour
{
	[SerializeField] private Grower grower;

	public void OnStageChanged() {
		transform.localScale = new Vector2(grower.stage + 1, grower.stage + 1);
	}
}
