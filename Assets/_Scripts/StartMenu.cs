using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    //[SerializeField] private Button _onePlayerButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _howToPlayButton;
    //[SerializeField] private string _gameScene = "GameScene";

    public delegate void StartMenuAction();
    public static event StartMenuAction OnHowToPlayClicked;
    private void Awake()
    {
        //_onePlayerButton.onClick.AddListener(OnStartButtonClick);
        _quitButton.onClick.AddListener(OnQuitButtonClick);
        _howToPlayButton.onClick.AddListener(OnHowToPlayButtonClick);
    }

    private void OnDestroy()
    {
        //_onePlayerButton.onClick.RemoveAllListeners();
        _quitButton.onClick.RemoveAllListeners();
        _howToPlayButton.onClick.RemoveAllListeners();
    }

    //private void OnStartButtonClick()
    //{
    //    SceneManager.LoadScene(_gameScene);
    //}

    private void OnQuitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void OnHowToPlayButtonClick()
    {
        OnHowToPlayClicked?.Invoke();
    }


}
