using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HitBeat;

public class BeatDetector : MonoBehaviour
{
    public Transform Center;
    public Vector2 MousePosition;
    public Vector2 MouseDirection;
    [Space(20)]
    public Vector2 ClickPosition;
    public Vector2 ClickDirection;

    private GameObject _closestBeat;
    public static event Action OnPlayerClick;

    public LayerMask mask;

    public BeatCounter Counter;
    public GameObject ClickEffect;

    [Header("Determination")]
    public GameObject Excellent;
    public GameObject Good;
    public GameObject Bad;
    public GameObject Miss;

    private void Update()
    {
        MouseTrack();
        if (Input.GetMouseButtonDown(0))
            Click();
    }
    private void MouseTrack()
    {
        Ray castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.position = new Vector3(castPoint.origin.x, castPoint.origin.y, 0f);
        MousePosition = transform.position - Center.position;
        MouseDirection = Vector3.Normalize(MousePosition);
    }
    public GameObject DealClosestBeat()
    {
        _closestBeat = NodeInventory.FindClosestNode(ClickDirection);
        if (_closestBeat == null)
            return null;

        NodeInventory.DeleteNode(_closestBeat);
        return _closestBeat;

    }
    private void Click()
    {
        ClickPosition = transform.position;
        ClickDirection = Vector3.Normalize(ClickPosition);
        
        RaycastHit2D hit =  Physics2D.Raycast(Center.position, ClickDirection, Vector3.Distance(Center.position, ClickPosition), mask);

        if (hit.collider != null)
        {
            HitBeat.CorrectType correctType = hit.collider.gameObject.GetComponent<HitBeat>().OnHitBeat();
            Counter.AddBeat(correctType);
            SpawnDetermine(correctType, hit.collider.gameObject.transform.position);
            Instantiate(ClickEffect, hit.collider.gameObject.transform.position, Quaternion.identity);
            Destroy(hit.collider.gameObject);
        }
        OnPlayerClick?.Invoke();
    }
    private void SpawnDetermine(HitBeat.CorrectType correctType, Vector3 position)
    {
        position += new Vector3(0.3f, 0.3f, 0f);

        if (correctType == HitBeat.CorrectType.Excellent)
            Instantiate(Excellent, position, Quaternion.identity);
        else if (correctType == HitBeat.CorrectType.Good)
            Instantiate(Good, position, Quaternion.identity);
        else if (correctType == HitBeat.CorrectType.Bad)
            Instantiate(Bad, position, Quaternion.identity);
        else
            Instantiate(Miss, position, Quaternion.identity);
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawLine(Center.position, MouseDirection);
    //}
}
