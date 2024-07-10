using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenHit : MonoBehaviour
{
    public LayerMask targetlayer;

    Collider collider;
    List<Animator> animator =  new List<Animator>();
    List<AnimalTransparency> animaltransparency = new List<AnimalTransparency>();
    AudioSource audio;


    private void Awake()
    {
        collider = GetComponent<Collider>();
        for (int i = 0; i < transform.childCount; i++)
        {
            animator.Add(transform.GetChild(i).GetComponent<Animator>());
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            animaltransparency.Add(transform.GetChild(i).GetComponent<AnimalTransparency>());
        }
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print($"¿©¿ì·¹À× {other.gameObject.layer} Å¸°Ù·¹ÀÌ¾î {targetlayer}");

        if (other.gameObject.layer == 6)
        {
            foreach (Animator anim in animator)
            {
                anim.SetTrigger("IsFear");
            }
            StartCoroutine(Attacted());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == targetlayer)
        {
            StopCoroutine(Attacted());
        }
    }

    IEnumerator ChickenDead()
    {
        audio.Play();
        GameManager.Instance.Life = 1;
        foreach (AnimalTransparency animal in animaltransparency)
        {
            animal.DisspearCoroutine();
        }
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

    IEnumerator Attacted()
    {
        yield return new WaitForSeconds(3.5f);
        foreach (Animator anim in animator)
        {
            anim.SetTrigger("IsDead");
        }
        StartCoroutine(ChickenDead());
    }
}
