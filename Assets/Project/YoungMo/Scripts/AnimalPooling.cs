using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoxArr
{
    public GameObject henTransform;

    public GameObject foxObject;

    public Transform foxSpawnPoint;

}

public class AnimalPooling : MonoBehaviour
{
    public static AnimalPooling instance;


    public GameObject foxPrefab;

    public List<FoxArr> foxarr;

    public int[] foxIndexArr = { 0, 0, 0, 0, 0 };

    // 리스트 말고 2차원 배열로 지정해 놓는게 나을 것 같음
    // 닭이 죽고나서 4초정도 후에 부활해야 하는데
    // 그냥 1차원 배열 해놓고 값으로 비교해도 될 것 같음

    /*
        index: 0 1 2 3 4
        value: 0 0 0 0 0
        
        이런 식으로 만들고 뽑지 않을 숫자는 0을 1로 만들어서 뽑지 않음
    
        게임 매니저나 어디서든 닭이 4초 후에 부활하면 여우 인덱스가 1이 된걸 0으로 다시 바꾸기

        이렇게 되면 foxController에서 공격 후 사라져 1을 0으로 만드는 것만 하면 될듯 add는 하지 않고
    */


    public float foxSpawnPeriod = 3.0f;

    public bool OnGame = true;

    bool isUnique;

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

    int rndValue;

    private void Awake()
    {
        instance = this;
    }

    private IEnumerator Start()
    {

        while (OnGame)
        {
            if(GameManager.Instance.Playing)
            {
                List<int> zeroIndexes = new List<int>();

                for (int i = 0; i < foxIndexArr.Length; ++i)
                {
                    if (foxIndexArr[i] == 0)
                    {
                        zeroIndexes.Add(i);
                    }
                }

                if (zeroIndexes.Count > 0)
                {
                    int randomIndex = zeroIndexes[Random.Range(0, zeroIndexes.Count)];
                    foxIndexArr[randomIndex] = 1;
                    //print($"randomIndex : {randomIndex}");
                    FoxSpawn(randomIndex);
                }

            }
            yield return new WaitForSeconds(foxSpawnPeriod);

        }
    }

    void FoxSpawn(int index)
    {
        //print($"index: {index}");

        if (foxarr[index].foxObject == null)
        {
            GameObject foxPrefabIntance = Instantiate(foxPrefab, foxarr[index].foxSpawnPoint.position, foxarr[index].foxSpawnPoint.rotation);
            foxarr[index].foxObject = foxPrefabIntance;

            foxarr[index].foxObject.GetComponent<FoxController>().SetHenTransform(foxarr[index].henTransform);
            foxarr[index].foxObject.GetComponent<FoxController>().SetFoxSpawnPoint(foxarr[index].foxSpawnPoint);

            foxarr[index].foxObject.GetComponent<FoxController>().SetIndex(index);

            foxarr[index].foxObject.GetComponent<FoxController>().SetFoxTransform();

        }
        else
        {
            foxarr[index].foxObject.SetActive(true);
        }

    }


}
