using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeOverBeat : OnBeatBehaviour
{
    [SerializeField] AnimationCurve sizeOverDistance;

    Vector3 initialScale;

    private void Awake()
    {
        initialScale = transform.localScale;    
    }
    private void Update()
    {
        float size = sizeOverDistance.Evaluate(BeatHandler.Instance.BeatDistance);

        transform.localScale = initialScale * size;
    }

}
