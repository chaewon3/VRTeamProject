using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    BulletPooling pool;
    float speed = 1000f;
    public Transform SpawnPoint;

    void Awake()
    {
        if(pool == null)
        {
            pool = GetComponent<BulletPooling>();
        }
    }

    private void OnDisable()
    {
        StopCoroutine("DespawnCoroution");
    }

    public void Shoot()
    {
        GameObject obj = pool.GetObj();
        if(obj != null)
        {
            StartCoroutine(DespawnCoroution(obj));
            if (obj.TryGetComponent(out Rigidbody rigidBody))
                ApplyForce(rigidBody);
        }
    }

    void ApplyForce(Rigidbody rigidBody)
    {
        Vector3 force = SpawnPoint.forward * speed;
        rigidBody.AddForce(force);
    }

    IEnumerator DespawnCoroution(GameObject obj)
    {
        yield return new WaitForSeconds(.5f);
        obj.SetActive(false);
    }
}
