using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class EndGame : MonoBehaviour
{
    public ScoreCounter Counter;
    [HideInInspector]
    public int Score;
    public UnityEvent OnEndGame;

    public TextMeshProUGUI _score;

    public Ranking Rank;

    private bool isEnd = false;
    public AudioSource m_Source;
    
    private void OnEnable()
    {
        isEnd = false;
    }
    private void Update()
    {
        if (!m_Source.isPlaying && !isEnd)
            EndofGame();
    }
    public void EndofGame()
    {
        if (isEnd)
            return;
        isEnd = true;
        Score = Counter.Score;
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(true);
        OnEndGame.Invoke();
        Result();
    }
    public void Result()
    {
        StartCoroutine(Calculate());
    }
    IEnumerator Calculate()
    {
        int current = 0;
        for (float f = 0f; f <= 1f; f += Time.deltaTime)
        {
            current = (int)Mathf.Lerp(0, Score, f);
            _score.text = "Your score : " + current.ToString();
            yield return null;
        }
        current = Score - 30;
        while (current < Score)
        {
            current++;
            _score.text = "Your score : " + current.ToString();
            yield return null;
        }
        Rank.Rank(Score);
    }
}
