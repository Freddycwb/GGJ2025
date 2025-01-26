using UnityEngine;
using UnityEngine.Events;

public class ManualStateSwitcher : MonoBehaviour
{
	[SerializeField] private GameObject duckSpawner;
	[SerializeField] private GameStateVariable gameState;
	[SerializeField] private BoolVariable manualMode;

	[SerializeField] private float manualStateTime;
	[SerializeField] private float autoStateTime;
	[SerializeField] private InvokeAfterTimer stateTime;

	public UnityEvent EnterMode1;
	public UnityEvent EnterMode2;
	public UnityEvent EnterMode3;

	private void Refresh() {
		if (manualMode.Value) {
			duckSpawner.SetActive(false);
			stateTime.SetTimeToAction(manualStateTime);
		} else {
			duckSpawner.SetActive(true);
			stateTime.SetTimeToAction(autoStateTime);
		}
	}

	private void Start() {
		Refresh();
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.F)) {
			manualMode.Value = !manualMode.Value;
			Refresh();
		}

		if (!manualMode.Value) return;

		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			duckSpawner.SetActive(false);
			EnterMode1?.Invoke();
		} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			duckSpawner.SetActive(true);
			gameState.Value = GameState.DuckState;
			EnterMode2?.Invoke();
		} else if (Input.GetKeyDown(KeyCode.Alpha3)) {
			gameState.Value = GameState.GoldBubbleState;
			EnterMode3?.Invoke();
		}
	}
}
