using UnityEngine;

public class RotateToDirection : MonoBehaviour {
	[SerializeField] private GameObject dirObj;
	private IInputDirection dir;

	[SerializeField] private float offset;

	private void Awake() {
		dir = dirObj.GetComponent<IInputDirection>();
	}

	private void Update() {
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(dir.direction.y, dir.direction.x) * Mathf.Rad2Deg + offset);
	}
}
