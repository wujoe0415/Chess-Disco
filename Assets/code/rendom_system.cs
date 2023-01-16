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

    //要被生成的怪物物件

    public GameObject susprise_effect;

    void Start()

    {

        //執行生成怪物程式碼(每秒一次)

        InvokeRepeating("CreatMoneter", 1, 1);

    }

    public void CreatMoneter()

    {

        int SuspriseNum;

        //隨機決定要生成幾個怪物(0-2個隨機)

        SuspriseNum = Random.Range(0, 3);

        //開始生成怪物

        for (int i = 0; i < SuspriseNum; i++)

        {

            //宣告生成的X座標

            float x,y;

            //產生隨機的X座標(-6到5之間)

            x = Random.Range(-6, 6);
            y = Random.Range(-6, 6);
            //生成怪物

            Instantiate(susprise_effect, new Vector3(x, 2.8f, 0), Quaternion.identity);

        }

    }

}