using UnityEngine;

public class StateController : MonoBehaviour
{
	[SerializeField] private GameStateVariable gameState;

	[SerializeField] private BoolVariable manualMode;

	[SerializeField] private float autoDuckChance;
	[SerializeField] private float duckChance;
	[SerializeField] private float goldChance;

	public void RandomizeGameState() {
		if (manualMode.Value) {
			gameState.Value = Random.Range(0, 100) < autoDuckChance?
				GameState.DuckState :
				GameState.NONE;
		} else {
			int r = Random.Range(0, 100);
			if (r < duckChance) {
				gameState.Value = GameState.DuckState;
			} else if (r < duckChance + goldChance) {
				gameState.Value = GameState.GoldBubbleState;
			} else {
				gameState.Value = GameState.NONE;
			}
		}
	}

	public void ChangeGameState(GameState state) {
		gameState.Value = state;
	}
}
