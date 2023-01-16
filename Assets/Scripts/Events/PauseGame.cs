using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseUI;
    private bool isPause = false;
    public static event Action OnPauseGame;
    public static event Action OnResumeGame;

    private void Awake()
    {
        pauseUI.SetActive(false);
        isPause = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPause)
            Pause();
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause)
            Resume();
    }
    private void Pause()
    {
        Time.timeScale = 0;
        pauseUI.SetActive(true);
        isPause = true;
        OnPauseGame?.Invoke();
    }
    private void Resume()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        isPause = false;
        OnResumeGame?.Invoke();
    }
}
