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

    // ����Ʈ�� �ٲٰ� ���찡 ����Ʈ �����ϰ� �����
    // ������ List.count�� �ϸ� �� �� ����
    public List<FoxArr> foxarr;

    
    public float foxSpawnPeriod = 1.0f;

    public bool OnGame = true;

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
    int newRndValue;

    private IEnumerator Start()
    {

        while (OnGame)
        {
            yield return new WaitForSeconds(foxSpawnPeriod);

            rndValue = Random.Range(0, 5);


            // ������Ʈ�� null���� üũ�ϰ� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ��� üũ�ؾ� ��

            // ���� �ߴ� ������ canMove�� true�� �Ǵµ� true�� �Ǿ��� �� ������Ʈ ���� �ִ� Ʈ�������� �������� ���ϱ� ������ �߻�
            // �ϴ� �� ����

            if (foxarr[rndValue].foxObject == null)
            {
                print("null");
            }

            if (foxarr[rndValue].foxSpawnPoint == null)
            {
                print("point null");
            }

            if (foxarr[rndValue].henTransform == null)
            {
                print("hen null");
            }

            FoxSpawn(rndValue);
        }
    }

    void FoxSpawn(int index)
    {

        if (foxarr[index].foxObject == null)
        {

            GameObject foxPrefabIntance = Instantiate(foxPrefab, foxarr[index].foxSpawnPoint.position, foxarr[index].foxSpawnPoint.rotation);
            foxarr[index].foxObject = foxPrefabIntance;

            foxarr[index].foxObject.GetComponent<FoxController>().SetHenTransform(foxarr[index].henTransform);
            foxarr[index].foxObject.GetComponent<FoxController>().SetFoxSpawnPoint(foxarr[index].foxSpawnPoint);

            foxarr[index].foxObject.GetComponent<FoxController>().SetFoxTransform();

        }
        else
        {
            //foxarr[index].foxObject.GetComponent<FoxController>().SetFoxTransform();
            foxarr[index].foxObject.SetActive(true);
        }


    }



}
