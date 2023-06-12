using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button _onePlayerButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private string _gameScene = "GameScene";
    private void Awake()
    {
        _onePlayerButton.onClick.AddListener(OnStartButtonClick);
        _quitButton.onClick.AddListener(OnQuitButtonClick);
    }

    private void OnDestroy()
    {
        _onePlayerButton.onClick.RemoveAllListeners();
        _quitButton.onClick.RemoveAllListeners();
    }

    private void OnStartButtonClick()
    {
        SceneManager.LoadScene(_gameScene);
    }

    private void OnQuitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
