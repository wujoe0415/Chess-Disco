using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInventory
{
    public static List<GameObject> Nodes = new List<GameObject>();
    private static float _leastAngle = 10f;

    public static void AddNode(GameObject node)
    {
        Nodes.Add(node);
    }
    public static void DeleteNode(GameObject node)
    {
        Nodes.Remove(node);
    }
    public static GameObject FindClosestNode(Vector2 direction)
    {
        GameObject closestNode = null;
        float distance = 0f;
        foreach(GameObject node in Nodes)
        {
            float tempDistance = Vector2.Dot(node.transform.position, direction);
            float angle = tempDistance / (Vector2.SqrMagnitude(node.transform.position) * Vector2.SqrMagnitude(direction));
            if (angle < _leastAngle && distance < tempDistance)
            {
                distance = tempDistance;
                closestNode = node;
            }
        }
        return closestNode;
    }
    public static bool ContainNode(GameObject node)
    {
        if (Nodes.Contains(node))
            return true;
        else
            return false;
    }
}