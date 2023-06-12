using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WhatYouHaveMenu : MonoBehaviour
{
    [SerializeField] private GameObject _root;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _selectButton;
    [SerializeField] private Button _storeButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private string quitToMainScene = "MainMenuScene";

    public delegate void ClickStoreAction();
    public static event ClickStoreAction OnStoreClicked;
    
    public delegate void ClickCloseAction();
    public static event ClickCloseAction OnCloseClicked;
    private void Awake()
    {
        CanvasUI.OnClicked += PauseButtonPressed;
        _closeButton.onClick.AddListener(OnCloseClick);
        _quitButton.onClick.AddListener(OnQuitClick);
        _storeButton.onClick.AddListener(OnStoreClick);
        _selectButton.onClick.AddListener(OnSelectClick);
        _root.SetActive(false);
    }

    private void OnDestroy()
    {
        CanvasUI.OnClicked -= PauseButtonPressed;
        _closeButton.onClick.RemoveAllListeners();
        _quitButton.onClick.RemoveAllListeners();
        _storeButton.onClick.RemoveAllListeners();
        _selectButton.onClick.RemoveAllListeners();
    }

    private void PauseButtonPressed()
    {
        _root.SetActive(true);
    }

    private void OnCloseClick()
    {
        Time.timeScale = 1.0f;
        OnCloseClicked?.Invoke();
        _root.SetActive(false);
    }

    private void OnQuitClick()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(quitToMainScene);
    }

    private void OnStoreClick()
    {
        _root.SetActive(false);
        OnStoreClicked?.Invoke();
    }

    private void OnSelectClick()
    {

    }
}
