using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitChess : MonoBehaviour
{
    public Chessman ChessReference;
    private IPieceMovement _movement;

    private void OnEnable()
    {
        //NodeInventory.AddNode(this.gameObject);
    }
    private void OnDisable()
    {
        //if (NodeInventory.ContainNode(this.gameObject))
        //    NodeInventory.DeleteNode(this.gameObject);
    }
}
