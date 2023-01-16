using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HitBeat : MonoBehaviour
{
    public Vector3 ExcellentBeat;
    public static float _zoneRadius = 1.25f;

    public enum CorrectType
    {
        Excellent,
        Good,
        Bad,
        Miss
    };

    private CorrectType CheckType(float distance)
    {
        if (Mathf.Abs(_zoneRadius - distance) < 0.5f) // Excellent
            return CorrectType.Excellent;
        else if (Mathf.Abs(_zoneRadius - distance) < 0.75f) // Good
            return CorrectType.Good;
        else if (Mathf.Abs(_zoneRadius - distance) < 1f) // Bad
            return CorrectType.Bad;
        else // Miss
            return CorrectType.Miss;
    }
    public CorrectType OnHitBeat()
    {
        float distance = Vector3.Distance(transform.position, Vector3.zero);
        //float distance = Vector2.SqrMagnitude(new Vector2(transform.position.x, transform.position.y));
        //Debug.Log(distance);
        CorrectType hitType = CheckType(distance);
        return hitType;
    }
}
