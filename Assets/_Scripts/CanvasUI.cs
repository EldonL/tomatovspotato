using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasUI : MonoBehaviour
{
    [SerializeField] private Button pauseButton;

    public delegate void ClickPauseAction();
    public static event ClickPauseAction OnClicked;

    private void Awake()
    {
        pauseButton.onClick.AddListener(OnPauseClick);
        WhatYouHaveMenu.OnCloseClicked += OnWhatYouHaveMenuCloseClick;
    }

    private void OnDestroy()
    {
        pauseButton.onClick.RemoveAllListeners();
        WhatYouHaveMenu.OnCloseClicked -= OnWhatYouHaveMenuCloseClick;
    }
    private void OnPauseClick()
    {
        OnClicked?.Invoke();
        pauseButton.interactable = false;
        Time.timeScale = 0;
    }

    private void OnWhatYouHaveMenuCloseClick()
    {
        pauseButton.interactable = true;
    }
}
