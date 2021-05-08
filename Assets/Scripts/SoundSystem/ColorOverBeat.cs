using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorOverBeat : OnBeatBehaviour
{
    [SerializeField] Gradient gradient;
    [SerializeField] Renderer renderer;
    [SerializeField] Image image;

    [SerializeField] bool createMaterialInstance = true;

    Material material;

    private void Awake()
    {
        if (!renderer)
            renderer = GetComponent<Renderer>();

        else
        {
            if (createMaterialInstance)
            {
                material = Instantiate(renderer.material);
                renderer.material = material;
            }
        }
    }

    private void Update()
    {
        Color c = gradient.Evaluate(BeatHandler.Instance.BeatDistance);
        if (!renderer && image)
        {
            image.color = c;
        }
        else
        {
            material.color = c;
        }
    }
}
