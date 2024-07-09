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
        //        Debug.LogError("foxObject �Ǵ� foxSpawnPoint�� null�Դϴ�.");
        //    }
        //}
        //else
        //{
        //    Debug.LogError("foxarr[" + index + "]�� null�Դϴ�.");
        //}

    }



}
