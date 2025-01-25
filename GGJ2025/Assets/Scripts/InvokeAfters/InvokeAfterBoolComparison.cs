using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeAfterBoolComparison : InvokeAfter
{
    public enum ComparisonType
    {
        isTrue,
        isFalse
    }

    [SerializeField] private ComparisonType comparison;


    public void Compare(InvokeAfterSwitch value)
    {
        Compare(value.GetValue());
    }

    public void Compare(GameObject value)
    {
        Compare(value.activeSelf);
    }

    public void Compare(bool value)
    {
        if (value ^ (comparison == ComparisonType.isTrue))
        {
            CallSubAction();
        }
        else
        {
            CallAction();
        }
    }
}
