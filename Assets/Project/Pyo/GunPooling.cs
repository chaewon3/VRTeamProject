using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class GunPooling : MonoBehaviour
{
    public GameObject rightCont;
    public GameObject prefab;
    public Transform SpawnPoint;
    Queue<GameObject> pool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.GetComponentInChildren<ShootGun>().SetCont(rightCont.GetComponent<ActionBasedController>());
            obj.name = $"Gun{i}";
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetObj()
    {
        if (pool.Count == 0)
        {
            return null;
        }
        GameObject gun = pool.Dequeue();
        gun.SetActive(true);
        gun.GetComponent<Rigidbody>().useGravity = false;
        gun.transform.position = SpawnPoint.position;
        gun.transform.rotation = SpawnPoint.rotation;

        return gun;
    }

    public void ReturnObj(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
