using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateChest : MonoBehaviour
{
    public GameObject Chest;
    public float absX = 20.0f;
    public float absY = 10f;
    [Range(8f, 15f)]
    public float GapTime = 8f;
    private float currentTime = 0f;

    private void Update()
    {
        if (currentTime < GapTime)
            currentTime += Time.deltaTime;
        else
        {
            Instantiate();
            currentTime = 0f;
            GapTime = Random.Range(8f, 15f);
        }
    }
    private void Instantiate()
    {
        Vector3 pos = new Vector3(Random.Range(absX, -absX), Random.Range(absY, -absY), 0f);
        while(pos.sqrMagnitude < 1.75f * 1.75f)
            pos = new Vector3(Random.Range(absX, -absX), Random.Range(absY, -absY), 0f);
        GameObject tmp = Instantiate(Chest, pos, Quaternion.identity, transform);
    }
}
