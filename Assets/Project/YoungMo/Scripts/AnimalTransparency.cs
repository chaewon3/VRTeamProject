using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTransparency : MonoBehaviour
{
    private Renderer objectRenderer;

    // smoothness�� 0����
    // rgb �� 255, 237, 239

    float transparency;
    public float duration = 1.0f;

    private void Awake()
    {
        objectRenderer = GetComponentInChildren<Renderer>();

        Color newColor = new Color(255f / 255f, 237f / 255f, 239f / 255f);

        objectRenderer.material.color = newColor;
    }


    private void OnEnable()
    {
        AppearCoroutine();
    }

    public void DisspearCoroutine()
    {
        StartCoroutine(BeInvisible());
    }

    public void AppearCoroutine()
    {
        StartCoroutine(BeVisible());
    }

    IEnumerator BeInvisible()
    {
        float time = duration;
        transparency = 1.0f;

        objectRenderer.material.shader = Shader.Find("Standard");
        objectRenderer.material.SetFloat("_Mode", 3); // Transparent ���
        objectRenderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        objectRenderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        objectRenderer.material.SetInt("_ZWrite", 0);
        objectRenderer.material.DisableKeyword("_ALPHATEST_ON");
        objectRenderer.material.EnableKeyword("_ALPHABLEND_ON");
        objectRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        objectRenderer.material.renderQueue = 3000;

        while (true)
        {
            yield return null;
            time -= Time.deltaTime;
            transparency -= Time.deltaTime;

            Color color = objectRenderer.material.color;
            color.a = transparency;
            objectRenderer.material.color = color;

            if (time <= 0.01f)
            {
                break;
            }
        }
        
    }

    IEnumerator BeVisible()
    {
        float time = duration;
        transparency = 0;
        bool isOpaque = false;

        objectRenderer.material.shader = Shader.Find("Standard");
        objectRenderer.material.SetFloat("_Mode", 3); // Transparent ���
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

        objectRenderer.material.SetFloat("_Glossiness", 0f);

        while (true)
        {
            yield return null;

            time -= Time.deltaTime;
            transparency += Time.deltaTime;

            if (transparency >= 0.875f && !isOpaque)
            {
                objectRenderer.material.shader = Shader.Find("Standard");
                objectRenderer.material.SetFloat("_Mode", 0); // Opaque ���
                objectRenderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                objectRenderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                objectRenderer.material.SetInt("_ZWrite", 1);
                objectRenderer.material.DisableKeyword("_ALPHATEST_ON");
                objectRenderer.material.DisableKeyword("_ALPHABLEND_ON");
                objectRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                objectRenderer.material.renderQueue = -1;

                color = objectRenderer.material.color;
                color.a = 1f;
                objectRenderer.material.color = color;

                objectRenderer.material.SetFloat("_Glossiness", 0f);

                isOpaque = true;
            }
            else if(transparency <= 0.875f)
            {
                color = objectRenderer.material.color;
                color.a = transparency;
                objectRenderer.material.color = color;
            }



            if (time <= 0.01f)
            {
                break;
            }

        }

        
    }


}