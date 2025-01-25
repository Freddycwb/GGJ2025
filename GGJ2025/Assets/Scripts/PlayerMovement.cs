using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float maxDashStrength;
	[SerializeField] private float dashChargeSpeed;
	[HideInInspector] public float dashStrength;

	[SerializeField] private float deaccel;

	[SerializeField] private GameObject playerDirObj;
	[SerializeField] private GameObject playerMoveBtnObj;

	private IInputDirection playerDir;
	private IInputAction playerMoveBtn;

	[SerializeField] private Rigidbody2D rb;

	private void Awake() {
		playerDir = playerDirObj.GetComponent<IInputDirection>();
		playerMoveBtn = playerMoveBtnObj.GetComponent<IInputAction>();
	}

	private void Update() {
		// deaccel
		float newLen = Mathf.Clamp(rb.linearVelocity.magnitude - deaccel * Time.deltaTime, 0, rb.linearVelocity.magnitude);
		rb.linearVelocity = rb.linearVelocity.normalized * newLen;

		// charge
		if (playerMoveBtn.buttonHold) {
			dashStrength += dashChargeSpeed * Time.deltaTime;
			if (dashStrength > maxDashStrength) dashStrength = maxDashStrength;
			return;
		}

		// dash
		if (!playerMoveBtn.buttonUp) return;
		rb.linearVelocity = playerDir.direction * dashStrength;
		dashStrength = 0;
	}
}
