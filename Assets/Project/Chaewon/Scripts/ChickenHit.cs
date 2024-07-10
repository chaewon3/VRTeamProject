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


    List<GameObject> flocks = new List<GameObject>();
    int foxIndex;

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
        for (int i = 0; i < transform.childCount; i++)
        {
            flocks.Add(transform.GetChild(i).gameObject);
        }


        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            foreach (Animator anim in animator)
            {
                anim.SetTrigger("IsFear");
            }
            //StartCoroutine(Attacked());
        }
    }

    IEnumerator ChickenDead()
    {
        GameManager.Instance.Life = 1;
        foreach (AnimalTransparency animal in animaltransparency)
        {
            animal.DisspearCoroutine();
        }
        yield return new WaitForSeconds(1.0f);

        foreach (GameObject animal in flocks)
        {
            animal.SetActive(false);
        }
        StartCoroutine(RespawnFlock());
    }

    public void StartAttackedFunc()
    {
        StartCoroutine(Attacked());
    }

    IEnumerator Attacked()
    {
        AnimalPooling.instance.foxIndexArr[foxIndex] = 1;

        foreach (Animator anim in animator)
        {
            anim.SetTrigger("IsDead");
        }
        StartCoroutine(ChickenDead());

        yield return null;
    }

    IEnumerator RespawnFlock()
    {
        yield return new WaitForSeconds(4.0f);

        foreach (GameObject animal in flocks)
        {
            animal.SetActive(true);
        }

        AnimalPooling.instance.foxIndexArr[foxIndex] = 0;
    }

    public void SetIndex(int index)
    {
        foxIndex = index;
    }

}
