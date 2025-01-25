using System.Threading;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public GameObject obj_bubble;
    [SerializeField] public GameObject obj_bubbles_group;
    [SerializeField] private float _bubble_spawn_timer = 1.0f;
    [SerializeField] private int initial_bubbles = 10;
    private float timer_spawn;

    void Start()
    {
        CreateInitialBubbles();
    }

    // Update is called once per frame
    void Update()
    {
        timer_spawn += Time.deltaTime;

        if ( timer_spawn > _bubble_spawn_timer )
        {
            timer_spawn = 0;
            GameObject newBubble = (GameObject)Instantiate(obj_bubble, getRandomXYPositionInScreen(), Quaternion.identity, obj_bubbles_group.transform);
        }
    }

    private void CreateInitialBubbles()
    {
        for ( int i = 0; i < initial_bubbles; i++ )
        {
            Instantiate(obj_bubble, getRandomXYPositionInScreen(), Quaternion.identity, obj_bubbles_group.transform);
        }
    }

    private Vector2 getRandomXYPositionInScreen()
    {
        float posX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        float posY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);

        return new Vector2(posX, posY);
    }
}
