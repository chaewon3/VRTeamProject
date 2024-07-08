using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour
{
    Animator animator;


    public Transform ChickenTransform;

    // 이렇게 해놓고 오브젝트 풀링을 통해
    // 닭과 여우 스폰 위치를 저장하고 활성화 될때 부여하기
    // 활성화될 때 FoxAppearance 코드 실행 지금은 update에 있지만 코루틴으로 생성한 후 움직이기
    // 투명화 상태가 끝나면 움직이기

    // 트랜스폼을 틍록하고
    // 여우가 이동하게 만들기
    // 

}
