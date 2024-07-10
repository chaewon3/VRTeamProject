using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootGun : MonoBehaviour
{
    BulletPool pool;
    ActionBasedController targetCont;
    private InputActionReference activateRef;

    void Awake()
    {
        pool = FindObjectOfType<BulletPool>();
        targetCont = GameObject.Find("Right Controller").GetComponent<ActionBasedController>();
        print("targetCont วาด็ ");
        
    }

    public void OnActivate()
    {
        pool.Shoot();
    }

    private void OnEnable()
    {
        activateRef.action.performed += OnActivateEventCall;
    }
    private void OnDisable()
    {
        activateRef.action.performed -= OnActivateEventCall;
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        activateRef = targetCont.activateAction.reference;
        //activateRef.action.performed -= OnActivateEventCall;
        //activateRef.action.performed += OnActivateEventCall;
        ///*delegate (InputAction.CallbackContext context)
        //{
        //    TriggerActivate(context.performed);
        //};*/

    }

    private void OnActivateEventCall(InputAction.CallbackContext cont)
    {
        TriggerActivate(cont.performed);
    }


    public void TriggerActivate(bool isPush)
    {
        if (isPush)
        {
            pool.Shoot();
        }

    }
}
