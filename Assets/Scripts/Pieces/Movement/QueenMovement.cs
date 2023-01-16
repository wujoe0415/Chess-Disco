using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenMovement : PieceMovement
{
    private int _maxGapRoll = 3;

    public override void TraceMovement()
    {
        for (int i = 0; i < _round; i++)
        {
            if (Random.Range(0f, 1f) < 0.5f)
            {
                transform.position = StraightMove();
            }
            else
                transform.position = SlideMove();

            RecordedMovement.Push(transform.position);
        }
    }
    private Vector3 StraightMove()
    {
        int delta = Random.Range(1, _maxGapRoll);
        _currentRoll += delta;
        return Chessboard.BoardGrid[_currentRoll, _currentNeighbour];
    }
    private Vector3 SlideMove()
    {
        int delta = Random.Range(1, _maxGapRoll);
        _currentRoll = _currentRoll + delta;
        if (Random.Range(0f, 1f) < 0.5f)
        {
            _currentNeighbour = _currentNeighbour - delta;
            return Chessboard.BoardGrid[_currentRoll, _currentNeighbour];
        }
        else
        {
            _currentNeighbour = _currentNeighbour + delta;
            return Chessboard.BoardGrid[_currentRoll, _currentNeighbour];
        }
    }
}
