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

    // ����Ʈ ���� 2���� �迭�� ������ ���°� ���� �� ����
    // ���� �װ��� 4������ �Ŀ� ��Ȱ�ؾ� �ϴµ�
    // �׳� 1���� �迭 �س��� ������ ���ص� �� �� ����

    /*
        index: 0 1 2 3 4
        value: 0 0 0 0 0
        
        �̷� ������ ����� ���� ���� ���ڴ� 0�� 1�� ���� ���� ����
    
        ���� �Ŵ����� ��𼭵� ���� 4�� �Ŀ� ��Ȱ�ϸ� ���� �ε����� 1�� �Ȱ� 0���� �ٽ� �ٲٱ�

        �̷��� �Ǹ� foxController���� ���� �� ����� 1�� 0���� ����� �͸� �ϸ� �ɵ� add�� ���� �ʰ�
    */


    public float foxSpawnPeriod = 3.0f;

    public bool OnGame = true;

    bool isUnique;

    #region �� ��� ����
    /*
        ���� ������ �����ϰ� ���� ���� ��ä ���� ��������

        ���� �� �ϳ��� ���� ���ϸ� ��� �´� ��� Ȱ��ȭ

        ���� �״� ������ ���찡 �ͼ� �����ϴµ� �� �� �̳��� ������ ���ϸ� ����

        �� ������ �� ����� ����

        �ߵ��� �׾ ��Ȱ ����
        
        ������ �״� ��� �Ŀ� �������ϰ� �����
        
    */
    #endregion

    #region ���� ���� �� Ǯ�� ����
    /*
        foxSpawnPoint ����Ʈ�� ������ŭ FoxList�� foxPrefab�� �߰�

        �������� �߰��� ������ 

        �� ��ó�� �ݶ��̴��� �߰��� �Ŀ� ���찡 �����ؼ� 3�� �� �ݶ��̴���
        �Լ��� ���� �ִϸ��̼��� ���� �� Ȱ��ȭ��Ű�� 

        �ݶ��̴��� Ʈ���ŷ� ����� ���� �±׸� ���� �� ���� ontrigger ���� fear�� Ȱ��ȭ ��Ű��
        
        ���찡 Ʈ���� ������ Ʈ���� �ߵ� ��Ű��

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
