using System.Collections;
using UnityEngine;
using TMPro;

public class TimeLimit : MonoBehaviour
{
    public TextMeshProUGUI UISecond;
    public TextMeshProUGUI Count;
    public GameObject GameOverUI;

    float time;

    private IEnumerator Start()
    {
        time = 30;
        Count.text = "3";
        yield return new WaitForSeconds(1);
        Count.text = "2";
        yield return new WaitForSeconds(1);
        Count.text = "1";
        yield return new WaitForSeconds(1);
        Count.text = "Start";
        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.Playing = true;
        yield return new WaitForSeconds(0.5f);
        Count.enabled = false;
    }


    private void Update()
    {
        if(GameManager.Instance.Life <= 0)
        {
            time = 0;
        }
        if(GameManager.Instance.Playing)
        {
            time -= Time.deltaTime;
            UISecond.text = ((int)time).ToString();
        }
        if(time <=0)
        {
            GameManager.Instance.Playing = false;
            GameOverUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
