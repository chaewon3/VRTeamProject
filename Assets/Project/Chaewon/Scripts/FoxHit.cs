using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxHit : MonoBehaviour, IHitable
{
    public bool isDie;

    public float maxHP;
    public float currentHP;
    private Animator animation;
    private AnimalTransparency animaltransparency;

    private void Awake()
    {
        animation = GetComponent<Animator>();
        animaltransparency = GetComponent<AnimalTransparency>();
    }

    private void Update()
    {
        if (currentHP <= 0)
        {
            animation.SetTrigger("IsDead");
            animaltransparency.DisspearCoroutine();
            Destroy(this.gameObject, 1.5f);
        }
    }
    public void Hit(float damage)
    {
        currentHP -= damage;
    }
}
