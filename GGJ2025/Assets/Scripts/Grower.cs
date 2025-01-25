using System;
using UnityEngine;

public class Grower : MonoBehaviour
{
	[SerializeField] private IntVariable score;

	public int stage;
	public int totalStages;
	public int pointsPerStage;
	public float growAmount;

	public Action stageChanged;

	public void OnScoreChanged() {
		int oldStage = stage;
		stage = score.Value / pointsPerStage;
		if (oldStage != stage) stageChanged?.Invoke();
	}
}
