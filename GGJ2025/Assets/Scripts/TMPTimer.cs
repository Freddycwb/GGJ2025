using TMPro;
using UnityEngine;

public class TMPTimer : MonoBehaviour
{
    [SerializeField] private InvokeAfterTimer timer;
    [SerializeField] private TextMeshPro tmp;

    private void Update()
    {
        if (timer != null)
        {
            tmp.text = Mathf.Ceil(timer.GetCurrentTimePass()).ToString("F0");
        }   
    }
}
