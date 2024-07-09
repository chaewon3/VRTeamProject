using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoxArr
{
    public Transform henTransform;

    public GameObject foxObject;

    public Transform foxSpawnPoint;

}

public class AnimalPooling : MonoBehaviour
{
    public GameObject foxPrefab;

    public FoxArr[] foxarr;

    public float foxSpawnPeriod = 3.0f;

    public bool OnGame = true;

    #region 닭 목숨 관련
    /*
        닭은 무리로 존재하고 무리 내에 개채 수는 여러가지

        무리 중 하나라도 공격 당하면 모두 맞는 모션 활성화

        닭이 죽는 조건은 여우가 와서 공격하는데 몇 초 이내에 죽이지 못하면 죽음

        닭 무리가 곧 목숨의 개수

        닭들이 죽어도 부활 안함
        
        죽으면 죽는 모션 후에 스르륵하고 사라짐
        
    */
    #endregion

    #region 여우 스폰 및 풀링 관련
    /*
        foxSpawnPoint 리스트의 개수만큼 FoxList에 foxPrefab을 추가

        프리팹을 추가한 다음에 

        닭 근처에 콜라이더를 추가한 후에 여우가 도착해서 3초 후 콜라이더의
        함수를 공격 애니메이션이 끝난 후 활성화시키기 

        콜라이더를 트리거로 만들고 여우 태그를 가진 게 들어가면 ontrigger 에서 fear을 활성화 시키기
        
        여우가 트리거 내에서 트리거 발동 시키기

    */
    #endregion


    private IEnumerator Start()
    {
        while (OnGame)
        {
            yield return new WaitForSeconds(foxSpawnPeriod);
            int rndValue = Random.Range(0, 5);

            FoxSpawn(rndValue);


        }
    }

    void FoxSpawn(int index)
    {

        if (foxarr[index].foxObject != null)
        {
            //foxarr[index].foxObject.transform.position = foxarr[index].foxSpawnPoint.transform.position;
            //foxarr[index].foxObject.transform.rotation = foxarr[index].foxSpawnPoint.transform.rotation;
            foxarr[index].foxObject.GetComponent<FoxController>().SetHenTransform(foxarr[index].henTransform);
            foxarr[index].foxObject.GetComponent<FoxController>().SetFoxSpawnPoint(foxarr[index].foxSpawnPoint);
            foxarr[index].foxObject = Instantiate(foxPrefab, foxarr[index].foxSpawnPoint.position, foxarr[index].foxSpawnPoint.rotation);

            foxarr[index].foxObject.SetActive(true);
        }
        else
        {
            foxarr[index].foxObject.GetComponent<FoxController>().SetFoxTransform();
            foxarr[index].foxObject.SetActive(true);
        }
        //if (foxarr[index] != null)
        //{
        //    if (foxarr[index].foxObject != null && foxarr[index].foxSpawnPoint != null)
        //    {
        //        foxarr[index].foxObject.transform.position = foxarr[index].foxSpawnPoint.position;
        //        foxarr[index].foxObject.transform.rotation = foxarr[index].foxSpawnPoint.rotation;
        //        foxarr[index].foxObject.transform.localScale = foxarr[index].foxSpawnPoint.localScale;
        //    }
        //    else
        //    {
        //        Debug.LogError("foxObject 또는 foxSpawnPoint가 null입니다.");
        //    }
        //}
        //else
        //{
        //    Debug.LogError("foxarr[" + index + "]가 null입니다.");
        //}

    }



}
