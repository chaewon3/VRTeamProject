using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Image[] Hearts;
    public Color color;

    private void Update()
    {
        switch(GameManager.Instance.Life)
        {
            case 0: Hearts[0].color = color; goto case 1;
            case 1: Hearts[1].color = color; goto case 2;
            case 2: Hearts[2].color = color; goto case 3;
            case 3: Hearts[3].color = color; goto case 4;
            case 4: Hearts[4].color = color; goto case 5;
            case 5: break;
        }
    }
}
