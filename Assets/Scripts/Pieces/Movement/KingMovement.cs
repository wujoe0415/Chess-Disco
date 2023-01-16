using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMovement : PieceMovement
{
    public override void TraceMovement()
    {
        for (int i = 0; i < _round; i++)
        {
        //    if (Random.Range(0f, 1f) > 0.5f)
        //        transform.position = Chessboard.BoardGrid[_currentRoll += 2, _currentNeighbour++];
        //    else
        //        transform.position = Chessboard.BoardGrid[_currentRoll += 2, _currentNeighbour--];
            RecordedMovement.Push(transform.position);
        }
    }
}
