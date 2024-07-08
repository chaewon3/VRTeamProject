using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoxArr
{
    public Transform henTransform;

    public GameObject foxObject;

    public GameObject foxSpawnPoint;

}

public class AnimalPooling : MonoBehaviour
{
    

    public FoxArr[] foxarr;

    public float foxSpawnPeriod = 3.0f;


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
        yield return new WaitForSeconds(foxSpawnPeriod);
        int rndValue = Random.Range(0, 5);

        FoxSpawn(rndValue);
    }

    void FoxSpawn(int index)
    {

        if (foxarr[index].foxObject != null)
        {
            foxarr[index].foxObject.transform.position = foxarr[index].foxSpawnPoint.transform.position;
            foxarr[index].foxObject.transform.rotation = foxarr[index].foxSpawnPoint.transform.rotation;
        }




        switch (index)
        {
            case 0:

                break;
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
        }
    }


}
