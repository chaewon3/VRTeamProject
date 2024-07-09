using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour
{
    Animator animator;


    Transform henTransform;
    Transform foxSpawnPoint;

    // 이렇게 해놓고 오브젝트 풀링을 통해
    // 닭과 여우 스폰 위치를 저장하고 활성화 될때 부여하기
    // 활성화될 때 FoxAppearance 코드 실행 지금은 update에 있지만 코루틴으로 생성한 후 움직이기
    // 투명화 상태가 끝나면 움직이기

    // 트랜스폼을 틍록하고
    // 여우가 이동하게 만들기
    // 

    public float speed = 5f; // 이동 속도

    void Update()
    {
        // 현재 위치와 목표 위치를 가져옵니다.
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = henTransform.position;

        // 목표 위치를 바라보도록 회전합니다.
        Vector3 direction = (targetPosition - currentPosition).normalized;
        direction.y = 0; // Y축 회전을 고정합니다.

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
        }

        // 목표 위치로 이동합니다.
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
