using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessboard : MonoBehaviour
{
    public static Vector3[,] BoardGrid;
    public GameObject Point;

    public static int _neighbour = 32;
    public static int _roll = 20;

    private void Awake()
    {
        BoardGrid = new Vector3[_roll, _neighbour];
        for (int i = 0; i < _roll; i++)
        {
            for (int j = 0; j < _neighbour; j++)
            {
                BoardGrid[i, j] = CreateGrid(i, j);
                //GameObject.Instantiate(Point, BoardGrid[i, j], Quaternion.identity, transform);
            }
        }
    }

    private Vector3 CreateGrid(int roll, int neighbour)
    {
        Vector3 origin = Vector3.zero;
        float angle =  2 * Mathf.PI / _neighbour * neighbour;
        float offsetRoll = 1.5f;
        float radius = offsetRoll + 0.75f * roll;

        Vector3 pos = origin + new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0f);
        return pos;
    }
}
