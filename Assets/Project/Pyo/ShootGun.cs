using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootGun : MonoBehaviour
{
    BulletPool pool;

    //public ActionBasedController targetCont;
    ActionBasedController targetCont;
    private InputActionReference activateRef;

    private void Awake()
    {
        pool = FindObjectOfType<BulletPool>();
        //targetCont = FindObjectOfType<ActionBasedController>();


        //targetCont = GameObject.Find("Right Controller").GetComponent<ActionBasedController>();
        //activateRef = targetCont.activateAction.reference;
    }

    public void SetCont(ActionBasedController cont)
    {
        targetCont = cont;
        activateRef = targetCont.activateAction.reference;
    }

    public void OnActivate()
    {
        pool.Shoot();
    }

    private void OnEnable()
    {
        if(activateRef !=null)
        activateRef.action.performed += OnActivateEventCall;
    }
    private void OnDisable()
    {
        if (activateRef != null)
            activateRef.action.performed -= OnActivateEventCall;
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
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
