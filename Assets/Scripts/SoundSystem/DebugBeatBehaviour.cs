using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugBeatBehaviour : OnBeatBehaviour
{
    public override void OnBeat()
    {
        Debug.Log($"Beat Fired at {Time.time}");
    }
}
