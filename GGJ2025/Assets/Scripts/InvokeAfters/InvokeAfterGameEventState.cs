using UnityEngine;

public class InvokeAfterGameEventState : InvokeAfter
{
	public GameEventState Event;

	public GameState targetState;

	private void OnEnable() {
		Event.RegisterListener(this);
	}

	private void OnDisable() {
		Event.UnregisterListener(this);
	}

	public virtual void OnEventRaised(GameState state) {
		if (state == targetState) {
			CallAction();
		} else {
			CallSubAction();
		}
	}
}
