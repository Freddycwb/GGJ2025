using UnityEngine;
using UnityEngine.Events;

public class Bubble : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float max_time_alive = 10.0f;
    [SerializeField] private float min_time_alive = 5.0f;
    private float time_alive;
    private float time = 0;
    [SerializeField] public UnityEvent lifetime_over;

    void Start()
    {
        GetComponentInChildren<Renderer>().material.SetFloat("_TimeOffset", Time.time);
        time_alive = Random.Range(min_time_alive, max_time_alive);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > time_alive)
        {
            lifetime_over.Invoke();
            Destroy(gameObject, 2);
        }
    }
}
