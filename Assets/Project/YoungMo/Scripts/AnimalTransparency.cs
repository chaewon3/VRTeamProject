using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTransparency : MonoBehaviour
{
    private Renderer objectRenderer;

    // smoothness를 0으로
    // rgb 는 255, 237, 239


    [Range(0, 1)]
    public float transparency = 0;

    private void Start()
    {
        objectRenderer = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        if (objectRenderer != null)
        {
            if (transparency <= 0.775f)
            {
                objectRenderer.material.shader = Shader.Find("Standard");
                objectRenderer.material.SetFloat("_Mode", 3); // Transparent 모드
                objectRenderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                objectRenderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                objectRenderer.material.SetInt("_ZWrite", 0);
                objectRenderer.material.DisableKeyword("_ALPHATEST_ON");
                objectRenderer.material.EnableKeyword("_ALPHABLEND_ON");
                objectRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                objectRenderer.material.renderQueue = 3000;

                Color color = objectRenderer.material.color;
                color.a = transparency;
                objectRenderer.material.color = color;
            }
            else
            {
                objectRenderer.material.shader = Shader.Find("Standard");
                objectRenderer.material.SetFloat("_Mode", 0); // Opaque 모드
                objectRenderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                objectRenderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                objectRenderer.material.SetInt("_ZWrite", 1);
                objectRenderer.material.DisableKeyword("_ALPHATEST_ON");
                objectRenderer.material.DisableKeyword("_ALPHABLEND_ON");
                objectRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                objectRenderer.material.renderQueue = -1;


                Color color = objectRenderer.material.color;
                color.a = 1f;
                objectRenderer.material.color = color;
            }
        }
    }

    public void SetTransparency(float alpha)
    {
        if (objectRenderer != null)
        {
            Color color = objectRenderer.material.color;
            color.a = alpha;
            objectRenderer.material.color = color;
        }
    }
}