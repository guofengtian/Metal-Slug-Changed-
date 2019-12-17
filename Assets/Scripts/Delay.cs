using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Delay : MonoBehaviour
{
    public static IEnumerator DelayToInvoke(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }

}
