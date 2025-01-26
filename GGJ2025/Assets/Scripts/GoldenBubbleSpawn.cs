using UnityEngine;

public class GoldenBubbleSpawn : MonoBehaviour
{
    private Vector2[] positions =
    {
        new Vector2(  0,  9),
        new Vector2( 14,  0),
        new Vector2(  0, -9),
        new Vector2(-14,  0),
    };

    private void Awake()
    {
        transform.position = positions[Random.Range(0, positions.Length)];
    }
}
