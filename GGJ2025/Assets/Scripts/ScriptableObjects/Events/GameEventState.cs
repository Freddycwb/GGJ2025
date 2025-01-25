using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEventState : ScriptableObject
{
    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>
    private readonly List<InvokeAfterGameEventState> _eventListeners =
        new List<InvokeAfterGameEventState>();

    public void Raise(GameState state)
    {
        for (int i = _eventListeners.Count - 1; i >= 0; i--)
            _eventListeners[i].OnEventRaised(state);
    }

    public void RegisterListener(InvokeAfterGameEventState listener)
    {
        if (!_eventListeners.Contains(listener))
            _eventListeners.Add(listener);
    }

    public void UnregisterListener(InvokeAfterGameEventState listener)
    {
        if (_eventListeners.Contains(listener))
            _eventListeners.Remove(listener);
    }
}
