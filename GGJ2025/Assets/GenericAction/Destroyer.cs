using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private float delay;
    [SerializeField] private bool onEnable;
    private Coroutine coroutine;

    public Action<Destroyer> onDelete;

    public float GetDelay()
    {
        return delay;
    }

    private void OnEnable()
    {
        if (onEnable)
        {
            Delete();
        }
    }

    private void CheckDelay()
    {
        if (delay > 0)
        {
            Delete();
        }
        else
        {
            DeleteNow();
        }
    }

    public void Delete()
    {
        if (coroutine != null) 
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(DeleteRoutine());
    }

    public void Delete(float value)
    {
        delay = value;
        CheckDelay();
    }

    public void Delete(GameObject value)
    {
        obj = value;
        CheckDelay();
    }

    private IEnumerator DeleteRoutine()
    {
        yield return new WaitForSeconds(delay);
        if (onDelete != null)
        {
            onDelete.Invoke(this);
        }
        yield return new WaitForEndOfFrame();
    }

    private void DeleteNow()
    {
        if (onDelete != null)
        {
            onDelete.Invoke(this);
        }
    }


    private void OnDestroy()
    {
        StopCoroutine(DeleteRoutine());
    }
}
