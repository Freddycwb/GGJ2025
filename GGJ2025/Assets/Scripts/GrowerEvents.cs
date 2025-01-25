using UnityEngine;
using UnityEngine.Events;

public class GrowerEvents : MonoBehaviour
{
	[SerializeField] private Grower grower;
	public UnityEvent onStageChanged;

	private void Start() {
		grower.stageChanged += OnStageChanged;
	}

	public void OnStageChanged() {
		onStageChanged?.Invoke();
	}

	private void OnDestroy() {
		grower.stageChanged -= OnStageChanged;
	}
}
