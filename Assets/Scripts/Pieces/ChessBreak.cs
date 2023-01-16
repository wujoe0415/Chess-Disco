using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBreak : MonoBehaviour
{
    public float Duration = 1.0f;
    private void OnEnable()
    {
        Invoke("DestroySelf", Duration);
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
