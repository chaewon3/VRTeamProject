using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletPooling : MonoBehaviour
{
    public GameObject prefab;
    public Transform SpawnPoint;
    List<GameObject> pool = new List<GameObject>();
    private int bulletCount;
    public TextMeshProUGUI bulletCountText;

    void Awake()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.transform.position = SpawnPoint.position;
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    void OnEnable()
    {
        bulletCount = 0;
        bulletCountText.text = (6 - bulletCount).ToString();
    }

    void OnDisable()
    {
        for(int i = 0; i< pool.Count; i++)
        {
            pool[i].SetActive(false);
        }
    }

    public GameObject GetObj()
    {
        if(bulletCount != pool.Count)
        {
            pool[bulletCount].transform.position = SpawnPoint.position;
            pool[bulletCount].SetActive(true);
            bulletCount++;
            bulletCountText.text = (6 - bulletCount).ToString();
            return pool[bulletCount-1];
            print("여긴 실행 안 되지");
        }
        else
        {
            return null;
        }
    }
}
