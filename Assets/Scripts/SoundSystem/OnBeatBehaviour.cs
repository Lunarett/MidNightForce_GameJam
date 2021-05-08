using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnBeatBehaviour : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        BeatHandler.Instance.RegisterBeatBehaviour(this);
    }

    protected virtual void OnDestroy()
    {
        if (BeatHandler.Instance)
            BeatHandler.Instance.UnregisterBeatBehaviour(this);
    }


    public virtual void OnBeat() { }

}



