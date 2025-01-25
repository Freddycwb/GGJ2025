using UnityEngine;

[CreateAssetMenu]
public class GameStateVariable : ScriptableObject
{
	[Multiline]
	public string DeveloperDescription = "";

	[SerializeField] private GameEventState stateEvent;

	private GameState _value;
	public GameState Value {
		get => _value;
		set {
			_value = value;
			stateEvent.Raise(_value);
		}
	}


	public bool PersistBetweenScenes = false;

	private void OnEnable()
	{
		if (PersistBetweenScenes)
		{
			hideFlags = HideFlags.DontUnloadUnusedAsset;
		}
	}
}

