using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Duck : MonoBehaviour
{
	[SerializeField] private float lifetime;
	[SerializeField] private float delayTime;

	[SerializeField] private float speed;

	[SerializeField] private float verticalRange;

	[SerializeField] private GameObject collider;
	[SerializeField] private float colliderDelay;

	[SerializeField] private float yPosRange;

	private Vector3 velocity;
	private float startTime;
	private bool colActivated;

	private void Start() {
		transform.position = new Vector3(Random.Range(0, 2) > 0? transform.position.x : -transform.position.x, transform.position.y + Random.Range(-yPosRange, yPosRange), 0);

		float x = transform.position.x < 0.0f? 1 : -1;
		float y = Random.Range(-verticalRange, verticalRange);
		Vector2 dir = new Vector2(x, y).normalized;
		velocity = dir * speed;

		startTime = Time.time;
	}

	private void Update() {
		float elapsed = Time.time - startTime;

		if (elapsed >= lifetime) {
			Destroy(gameObject);
			return;
		}

		if (!colActivated && elapsed >= colliderDelay) {
			collider.SetActive(true);
			colActivated = true;
		}

		// deaccel
		float newLen = speed * (1 - elapsed/lifetime);
		velocity = velocity.normalized * newLen;

		// move
		transform.position += velocity * Time.deltaTime;
	}
}

