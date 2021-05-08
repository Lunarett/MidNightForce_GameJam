using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeOverBeat : OnBeatBehaviour
{
    [SerializeField] AnimationCurve sizeOverDistance;
    [SerializeField] bool useClipped;
    
    Vector3 initialScale;

    private void Awake()
    {
        initialScale = transform.localScale;    
    }
    private void Update()
    {
        float value = useClipped ? BeatHandler.Instance.BeatDistanceClipped : BeatHandler.Instance.BeatDistance;

        float size = sizeOverDistance.Evaluate(value);

        transform.localScale = initialScale * size;
    }

}
