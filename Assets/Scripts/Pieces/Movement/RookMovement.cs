using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookMovement : PieceMovement
{
    private int _regionRoll = 7;
    private int _maxGapRoll = 3;

    public override void TraceMovement()
    {
        for (int i = 0; i < _round; i++)
        {
            _currentRoll += Random.Range(1, _maxGapRoll);
            transform.position = Chessboard.BoardGrid[_currentRoll, _currentNeighbour];
            if(_currentRoll > _maxGapRoll)
            {
                if (Random.Range(0f, 1f) < 0.2)
                    BackrunTrace();
            }
            RecordedMovement.Push(transform.position);
        }
    }
    private void BackrunTrace()
    {
        int backGrid = Random.Range(1, _maxGapRoll);
        _currentRoll -= backGrid;
        transform.position = Chessboard.BoardGrid[_currentRoll, _currentNeighbour];
        RecordedMovement.Push(transform.position);
        _currentRoll += backGrid;
        transform.position = Chessboard.BoardGrid[_currentRoll, _currentNeighbour];
    }
}
