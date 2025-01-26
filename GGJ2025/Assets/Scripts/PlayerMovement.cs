using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float dashChargeTime;
	[HideInInspector] public float dashCurrentCharge;

	[SerializeField] private float maxDashStrength;
	[SerializeField] private float maxDashStrengthBig;

	[SerializeField] private float deaccel;

	[SerializeField] private GameObject playerDirObj;
	[SerializeField] private GameObject playerMoveBtnObj;

	private IInputDirection playerDir;
	private IInputAction playerMoveBtn;

	[SerializeField] private Rigidbody2D rb;

	[SerializeField] private Grower playerSize;

    public Action charge;
    public Action dash;
	private bool charging;

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
            if (charge != null && !charging)
            {
                charge.Invoke();
                charging = true;
            }
            dashCurrentCharge += Time.deltaTime;
			if (dashCurrentCharge > dashChargeTime) dashCurrentCharge = dashChargeTime;
			return;
		}

		// dash
		if (!playerMoveBtn.buttonUp) return;
		if (dash != null)
		{
            dash.Invoke();
			charging = false;
        }
		rb.linearVelocity = playerDir.direction * (dashCurrentCharge / dashChargeTime) * Mathf.Lerp(maxDashStrength, maxDashStrengthBig, (float)playerSize.stage / (float)playerSize.totalStages);
		dashCurrentCharge = 0;
	}
}
