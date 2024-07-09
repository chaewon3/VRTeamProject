using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IHitable>(out IHitable hitable))
        {
            hitable.Hit(damage);
        }

        Destroy(gameObject);
    }
}
