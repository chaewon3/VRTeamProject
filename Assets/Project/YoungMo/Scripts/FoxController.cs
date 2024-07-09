using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour
{
    Animator animator;


    Transform henTransform;
    public Transform foxSpawnPoint;
    bool alreadyReferred = false;

    // 이렇게 해놓고 오브젝트 풀링을 통해
    // 닭과 여우 스폰 위치를 저장하고 활성화 될때 부여하기
    // 활성화될 때 FoxAppearance 코드 실행 지금은 update에 있지만 코루틴으로 생성한 후 움직이기
    // 투명화 상태가 끝나면 움직이기

    // 트랜스폼을 틍록하고
    // 여우가 이동하게 만들기
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

    public float speed = 5f; // 이동 속도

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
