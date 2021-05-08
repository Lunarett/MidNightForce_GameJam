using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOverBeat : OnBeatBehaviour
{
    [SerializeField] Gradient gradient;
    [SerializeField] Renderer renderer;
    [SerializeField] bool createMaterialInstance = true;

    Material material;

    private void Awake()
    {
        if (!renderer)
            renderer = GetComponent<Renderer>();

        if (createMaterialInstance)
        {
            material = Instantiate(renderer.material);
            renderer.material = material;
        }
    }

    private void Update()
    {
        material.color = gradient.Evaluate(BeatHandler.Instance.BeatDistance);
    }
}
