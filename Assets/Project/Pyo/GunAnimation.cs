using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

//[RequireComponent(typeof(ActionBasedController))]
public class GunAnimation : MonoBehaviour
{
    //public Transform trigger;
    BulletPool pool;

    public ActionBasedController targetCont;
    private InputActionReference activateRef;

    private void Awake()
    {
        pool = FindObjectOfType<BulletPool>();
        //targetCont = GetComponent<ActionBasedController>(); 
    }

    public void OnActivate()
    {
        print("트리거 발동");
        pool.Shoot();
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        activateRef = targetCont.activateAction.reference;

        activateRef.action.performed += delegate (InputAction.CallbackContext context)
        {
            print("슛");
            TriggerActivate(context.performed);
        };

    }

    public void TriggerActivate(bool isPush)
    {
        print("트리거 발동");
        //trigger.transform.Rotate(0, 0, isPush ? 10 : -10);
        if (isPush)
        {
            pool.Shoot();
        }

    }
}
