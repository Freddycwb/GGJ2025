using UnityEngine;

public class StateController : MonoBehaviour
{
    public enum GameStates{
        NONE,
        STATE1,
        STATE2,
        STATE3,
    };

    [SerializeField] private GameEvent changeState;
    [SerializeField] public GameStates gameState = GameStates.NONE;

    public void changeGameState(GameStates state)
    {
        gameState = state;
        changeState.Raise();
    }

    private void CreateDuck()
    {

    }
}
