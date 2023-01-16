using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionZ : MonoBehaviour
{
    private void OnEnable()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }
}
