using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class MonsterCreater : MonoBehaviour

{

    //�n�Q�ͦ����Ǫ�����

    public GameObject susprise_effect;

    void Start()

    {

        //����ͦ��Ǫ��{���X(�C��@��)

        InvokeRepeating("CreatMoneter", 1, 1);

    }

    public void CreatMoneter()

    {

        int SuspriseNum;

        //�H���M�w�n�ͦ��X�өǪ�(0-2���H��)

        SuspriseNum = Random.Range(0, 3);

        //�}�l�ͦ��Ǫ�

        for (int i = 0; i < SuspriseNum; i++)

        {

            //�ŧi�ͦ���X�y��

            float x,y;

            //�����H����X�y��(-6��5����)

            x = Random.Range(-6, 6);
            y = Random.Range(-6, 6);
            //�ͦ��Ǫ�

            Instantiate(susprise_effect, new Vector3(x, 2.8f, 0), Quaternion.identity);

        }

    }

}