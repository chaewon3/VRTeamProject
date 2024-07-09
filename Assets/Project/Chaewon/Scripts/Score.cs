using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Image[] stars;
    public Color color;

    private void OnEnable()
    {
        switch(GameManager.Instance.Life)
        {
            case 0: 
                stars[0].color = color; goto case 1;
            case 1: 
            case 2:
                stars[1].color = color; goto case 3;
            case 3: 
            case 4:
                stars[2].color = color; goto case 5;
            case 5:
                break;
        }
    }

}
