using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement : PieceMovement
{
    public override void TraceMovement()
    {
        for (int i = 0; i < _round; i++)
        {
            _currentRoll++;
            transform.position = Chessboard.BoardGrid[_currentRoll, _currentNeighbour];
            RecordedMovement.Push(transform.position);
        }
    }
}
