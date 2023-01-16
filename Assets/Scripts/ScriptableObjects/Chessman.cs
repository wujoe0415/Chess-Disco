using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Chess", menuName = "Chessman", order = 1)]
public class Chessman : ScriptableObject
{
    public enum ChessType {
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn,
        None
    };
    public ChessType Type = ChessType.None;
    //public Sprite CoverImage;
}
