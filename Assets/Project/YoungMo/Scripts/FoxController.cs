using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour
{
    Animator animator;


    Transform henTransform;
    public Transform foxSpawnPoint;
    bool alreadyReferred = false;

    // �̷��� �س��� ������Ʈ Ǯ���� ����
    // �߰� ���� ���� ��ġ�� �����ϰ� Ȱ��ȭ �ɶ� �ο��ϱ�
    // Ȱ��ȭ�� �� FoxAppearance �ڵ� ���� ������ update�� ������ �ڷ�ƾ���� ������ �� �����̱�
    // ����ȭ ���°� ������ �����̱�

    // Ʈ�������� �v���ϰ�
    // ���찡 �̵��ϰ� �����
    // 

    AnimalTransparency at;
    bool canMove = false;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        if (alreadyReferred)
        {
            
        }
        at = GetComponent<AnimalTransparency>();
        StartCoroutine(FoxAppear());

    }

    IEnumerator FoxAppear()
    {
        SetFoxTransform();

        if (at == null)
        {
            print("at null");
        }
        //at.DisspearCoroutine();
        yield return new WaitForSeconds(at.duration);
        canMove = true;
    }

    public float speed = 5f; // �̵� �ӵ�

    void Update()
    {
        if (canMove)
        {
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = henTransform.position;

            Vector3 direction = (targetPosition - currentPosition).normalized;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
            }

            transform.position = Vector3.MoveTowards(currentPosition, new Vector3(targetPosition.x, currentPosition.y, targetPosition.z), speed * Time.deltaTime);

            if (Vector3.Magnitude(currentPosition - targetPosition) <= 1)
            {
                canMove = false;

            }
        }

    }

    IEnumerator FoxAttack()
    {
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }


    public void SetHenTransform(Transform value)
    {
        henTransform = value;
    }
    public void SetFoxSpawnPoint(Transform value)
    {
        foxSpawnPoint = value;
    }

    public void SetFoxTransform()
    {
        if (foxSpawnPoint == null)
        {
            print("foxspawn error");
            return;
        }

        if (this.gameObject == null)
        {
            print("foxObject error");
            return;
        }

        transform.position = foxSpawnPoint.position;
        transform.rotation = foxSpawnPoint.rotation;
    }

}
