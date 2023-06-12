using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasUI : MonoBehaviour
{
    [SerializeField] Button pauseButton;

    public delegate void ClickPauseAction();
    public static event ClickPauseAction OnClicked;

    private void Awake()
    {
        pauseButton.onClick.AddListener(OnPauseClick);
    }

    private void OnDestroy()
    {
        pauseButton.onClick.RemoveAllListeners();
    }
    private void OnPauseClick()
    {
        OnClicked?.Invoke();
        Time.timeScale = 0;
    }
}
