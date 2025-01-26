using System.Threading;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class GameController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public GameObject obj_bubble;
    [SerializeField] public GameObject obj_bubbles_group;
    [SerializeField] private float _bubble_spawn_timer = 1.0f;
    [SerializeField] private int initial_bubbles = 10;
    [SerializeField] private IntVariable[] scores;
    [SerializeField] private int max_score = 30;
    [SerializeField] private GameEvent gameIsOver;
    [SerializeField] private TextMeshPro tmp;

    [SerializeField] private Color[] playersColors;

    private bool _is_game_end = false;

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
            Vector2 new_position = getRandomXYPositionInScreen();

            GameObject newBubble = (GameObject)Instantiate(obj_bubble, new_position, Quaternion.identity, obj_bubbles_group.transform);
            // newBubble.transform.GetChild(1).GetComponent<SpriteRenderer>().material.SetFloat("_TimeOffset", Random.Range(0,1.0f));
            timer_spawn = 0;
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

    public void endGame()
    {
        Vector2 scorePlayer = new Vector2(0,0);
        int i = 0;
        foreach (var score in scores)
        {
            if ( score.Value >= scorePlayer.x )
            {
                scorePlayer.x = score.Value;
                scorePlayer.y = i;
            }
            i++;
        }
        finishGame((int)scorePlayer.y);
    }

    private void finishGame(int winner)
    {
        SetTextToPlayerColor(winner);
        tmp.text = "Player " + (winner + 1) + " Wins";
        gameIsOver.Raise();
    }

    private void SetTextToPlayerColor(int winner)
    {
        tmp.color = playersColors[winner];
    }
}
