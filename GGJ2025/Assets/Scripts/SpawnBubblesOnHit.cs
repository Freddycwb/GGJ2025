using UnityEngine;

public class SpawnBubblesOnHit : MonoBehaviour
{
    [SerializeField] private IntVariable score;
    [SerializeField] private Instantiator instantiator;

    public void SpawnBubblesByMod(float value)
    {
        instantiator.CreateXObjects(Mathf.FloorToInt(score.Value - (score.Value / value)));
        score.Value = Mathf.FloorToInt(score.Value / value);
    }
}
