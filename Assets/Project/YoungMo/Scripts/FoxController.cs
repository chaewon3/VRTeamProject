using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour
{
    Animator animator;


    Transform henTransform;
    Transform foxSpawnPoint;

    // �̷��� �س��� ������Ʈ Ǯ���� ����
    // �߰� ���� ���� ��ġ�� �����ϰ� Ȱ��ȭ �ɶ� �ο��ϱ�
    // Ȱ��ȭ�� �� FoxAppearance �ڵ� ���� ������ update�� ������ �ڷ�ƾ���� ������ �� �����̱�
    // ����ȭ ���°� ������ �����̱�

    // Ʈ�������� �v���ϰ�
    // ���찡 �̵��ϰ� �����
    // 

    public float speed = 5f; // �̵� �ӵ�

    void Update()
    {
        // ���� ��ġ�� ��ǥ ��ġ�� �����ɴϴ�.
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = henTransform.position;

        // ��ǥ ��ġ�� �ٶ󺸵��� ȸ���մϴ�.
        Vector3 direction = (targetPosition - currentPosition).normalized;
        direction.y = 0; // Y�� ȸ���� �����մϴ�.

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
        }

        // ��ǥ ��ġ�� �̵��մϴ�.
        transform.position = Vector3.MoveTowards(currentPosition, new Vector3(targetPosition.x, currentPosition.y, targetPosition.z), speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        
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
        transform.position = foxSpawnPoint.position;
        transform.rotation = foxSpawnPoint.rotation;
    }

}
