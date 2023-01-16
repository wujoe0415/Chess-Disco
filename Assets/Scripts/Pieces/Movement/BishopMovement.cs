using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopMovement : PieceMovement
{
    public override void TraceMovement()
    {
        for (int i = 0; i < _round; i++)
        {
            transform.position = SlideMove();
            RecordedMovement.Push(transform.position);
        }
    }
    private Vector3 SlideMove()
    {
        _currentRoll++;
        if (Random.Range(0f, 1f) > 0.5f)
            return Chessboard.BoardGrid[_currentRoll, _currentNeighbour--];
        else
            return Chessboard.BoardGrid[_currentRoll, _currentNeighbour++];
    }
}
