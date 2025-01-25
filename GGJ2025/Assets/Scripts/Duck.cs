using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Duck : MonoBehaviour
{

    public float delayTime;
    public Vector3 posA;
    public Vector3 posB;

    private void Awake()
    {
        posA = transform.position;
        posB = new Vector3(9.5f, transform.position.y, 0);
    }

    void Start()
    {
        StartCoroutine(WaitAndMove(delayTime));
    }

    IEnumerator WaitAndMove(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (Time.time - startTime <= 1)
        { // until one second passed
            transform.position = Vector3.Lerp(posA, posB, Time.time - startTime); // lerp from A to B in one second
            yield return 1; // wait for next frame
        }
        Destroy(gameObject);
    }
}
