using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CanvasUI : MonoBehaviour
{
    [SerializeField] private Button pauseButton;

    public delegate void ClickPauseAction();
    public static event ClickPauseAction OnClicked;
    public TextMeshProUGUI countDownText;
    private void Awake()
    {
        pauseButton.onClick.AddListener(OnPauseClick);
        WhatYouHaveMenu.OnCloseClicked += OnWhatYouHaveMenuCloseClick;
    }

    private void Start()
    {
        countDownText.text = "Ready";
        StartCoroutine(CountDownRoutine());
    }

    private void OnDestroy()
    {
        pauseButton.onClick.RemoveAllListeners();
        WhatYouHaveMenu.OnCloseClicked -= OnWhatYouHaveMenuCloseClick;
    }

    private IEnumerator CountDownRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        countDownText.text = "Set";
        yield return new WaitForSeconds(1.0f);
        countDownText.text = "GO";
        yield return new WaitForSeconds(0.2f);
        countDownText.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
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
