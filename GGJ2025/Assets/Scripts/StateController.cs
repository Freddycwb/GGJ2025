using System;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] private GameStateVariable gameState;

    public void RandomizeGameState() {
        Array enumValues = Enum.GetValues(typeof(GameState));
        gameState.Value = (GameState)enumValues.GetValue(UnityEngine.Random.Range(0, enumValues.Length));
    }

    public void ChangeGameState(GameState state)
    {
        gameState.Value = state;
    }
}
