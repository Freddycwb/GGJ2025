using UnityEngine;

public class ColorByPlayerCharge : MonoBehaviour
{
	private SpriteRenderer spr;
	[SerializeField] private PlayerMovement player;

	private void Awake() {
		spr = GetComponent<SpriteRenderer>();
	}

	private void Update() {
		spr.color = Color.Lerp(Color.white, Color.red, player.dashStrength / player.maxDashStrength);
	}
}
