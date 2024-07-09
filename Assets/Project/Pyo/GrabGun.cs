using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabGun : MonoBehaviour
{
    Rigidbody rigid;
    public InputActionProperty isGrab;
    bool firstGrab = false;
    bool objGrab = false;
    GunPool gunPool;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        gunPool = FindObjectOfType<GunPool>();
    }

    void OnEnable()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        
        rigid.useGravity = false;
        print($"{name} use gravity ? {rigid.useGravity}");
    }

    private void OnDisable()
    {
        firstGrab = false;
        objGrab = false;
    }

    void Update()
    {
        if(!firstGrab && isGrab.action.ReadValue<float>() > 0.1f)
        {
            firstGrab = true;
        }

        if (!objGrab && firstGrab && isGrab.action.ReadValue<float>() < 0.1f)
        {
            objGrab = true;
            Grab();
        }
    }

    void Grab()
    {
        print($"{name} grab");
        rigid.useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            gunPool.GetObject();
            gunPool.Despawn(gameObject);
            
        }
    }
}
