using UnityEngine;

public class GameStateSetter : MonoBehaviour
{
	[SerializeField] private GameStateVariable gameState;
	[SerializeField] private GameState nextState;

	public void ChangeState() {
		gameState.Value = nextState;
	}
}
