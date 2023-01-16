using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceMovement : MonoBehaviour, IPieceMovement
{
    public Stack<Vector3> RecordedMovement;
    public int _round;
    private int _roll;
    private int _neighbour;
    protected int _currentRoll {
        get {
            _roll = Mathf.Clamp(_roll, 0, Chessboard._roll - 1);
            return _roll;
        }
        set {
            _roll = Mathf.Clamp(value, 0, Chessboard._roll - 1);
        }
    }
    protected int _currentNeighbour{
        get { return _neighbour; }
        set
        {
            if (value >= Chessboard._neighbour)
                _neighbour = value - Chessboard._neighbour;
            else if (value < 0)
                _neighbour = Chessboard._neighbour + value - 1;
            else
                _neighbour = value;
        }
    }

    protected WaitForSeconds _delay = new WaitForSeconds(0.3f);
    public float Duration = 0.5f;
    public GameObject Excellent;
    public GameObject Miss;
    public float PerfectTime
    {
        get { return _round * Duration + 0.3f * _round ; }
    }
    public void InitializeData()
    {
        _round = Random.Range(7, 10);
        _currentRoll = 0;
        _currentNeighbour = Random.Range(0, 32);

        RecordedMovement = new Stack<Vector3>(_round);
        RecordedMovement.Push(Vector3.zero);
        // Perfect Time
        transform.position = Chessboard.BoardGrid[_currentRoll, _currentNeighbour];
        //Debug.Log(transform.position);
        RecordedMovement.Push(transform.position);
        TraceMovement();
    }
    public virtual void OnDisable()
    {
        StopCoroutine(Move());
    }
    public void OnDestroy()
    {
        StopCoroutine(Move());
        RecordedMovement.Clear();
    }
    public void Movement()
    {
        StartCoroutine(Move());
    }
    public virtual void TraceMovement()
    {
        for (int i = 0; i < _round; i++)
        {
            transform.position = Chessboard.BoardGrid[_currentRoll, _currentNeighbour];
            RecordedMovement.Push(transform.position);
        }
    }
    public virtual IEnumerator Move()
    {
        while (RecordedMovement.Count > 0)
        {
            if(RecordedMovement.Count == 1 && Imortal.isImortal)
            {
                GameObject.Instantiate(Miss, transform.position, Quaternion.identity);
                GameObject.Find("Player").GetComponent<BeatCounter>().AddBeat(HitBeat.CorrectType.Excellent);
                break;
            }
            Vector3 init = transform.position;
            Vector3 target = RecordedMovement.Pop();
            for (float f = 0f; f <= Duration; f += Time.deltaTime)
            {
                transform.position = Vector3.Lerp(init, target, f / Duration);
                yield return null;
            }
            transform.position = target;
            yield return _delay;
        }
        if (!Imortal.isImortal)
        {
            transform.position = Vector3.zero;
            GameObject.Instantiate(Miss, transform.position, Quaternion.identity);
            GameObject.Find("Player").GetComponent<BeatCounter>().AddBeat(HitBeat.CorrectType.Miss);
        }
        Destroy(gameObject);
    }
}
