using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject prefab;
    public Transform SpawnPoint;
    Queue<GameObject> pool = new Queue<GameObject>();

    void Awake()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject obj = Instantiate(prefab, SpawnPoint.position, Quaternion.identity);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetObj()
    {
        if (pool.Count == 0)
        {
            print(" null 반환");
            return null;
        }

        GameObject bullet = pool.Dequeue();
        bullet.SetActive(true);
        bullet.transform.position = SpawnPoint.position;
        bullet.transform.SetParent(null);
        print(" bullet 반환");

        return bullet;
    }

    public void ReturnObj(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        pool.Enqueue(obj);
    }

    
}
