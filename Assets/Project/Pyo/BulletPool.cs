using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    ObjectPooling pool;
    float speed = 300f;
    public Transform SpawnPoint;

    void Awake()
    {
        if(pool == null)
        {
            pool = GetComponent<ObjectPooling>();
        }
    }

    public void Shoot()
    {
        print(" shot ½ÇÇà");
        GameObject obj = pool.GetObj();
        StartCoroutine(DespawnCoroution(obj));
        if (obj.TryGetComponent(out Rigidbody rigidBody))
            ApplyForce(rigidBody);
    }

    void ApplyForce(Rigidbody rigidBody)
    {
        Vector3 force = SpawnPoint.forward * speed;
        rigidBody.AddForce(force);
    }

    IEnumerator DespawnCoroution(GameObject obj)
    {
        yield return new WaitForSeconds(3f);
        pool.ReturnObj(obj);
    }
}
