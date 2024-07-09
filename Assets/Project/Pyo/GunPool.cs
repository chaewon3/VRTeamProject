using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPool : MonoBehaviour
{
    GunPooling pool;
    public Transform SpawnPoint;

    void Awake()
    {
        if (pool == null)
        {
            pool = GetComponent<GunPooling>();
        }
    }

    void Start()
    {
        GetObject();
    }

    public void GetObject()
    {
        pool.GetObj();
    }

    public void Despawn(GameObject obj)
    {
        pool.ReturnObj(obj);
    }
}
