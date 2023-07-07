using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject _root;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private string quitToMainScene = "MainMenuScene";

    [SerializeField] private PlayerInformation player1;
    [SerializeField] private PlayerInformation player2;

    [SerializeField] private TextMeshProUGUI score1;
    [SerializeField] private TextMeshProUGUI score2;
    [SerializeField] private TextMeshProUGUI coin1;
    [SerializeField] private TextMeshProUGUI coin2;


    private void Awake()
    {
        _quitButton.onClick.AddListener(QuitButtonClick);
        _restartButton.onClick.AddListener(RestartButtonClick);
        _root.SetActive(false);
        ScoreManager.NoLivesEvent += NoLives;
    }

    private void OnDestroy()
    {
        _quitButton.onClick.RemoveAllListeners();
        _restartButton.onClick.RemoveAllListeners();
        ScoreManager.NoLivesEvent -= NoLives;
    }

    private void QuitButtonClick()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(quitToMainScene);
    }

    private void RestartButtonClick()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void NoLives()
    {
        Time.timeScale = 0.0f;
        score1.text = "Need to replace";
        score2.text = "Need to replace";
        coin1.text = "Need to replace";
        coin2.text = "Need to replace";

        _root.SetActive(true);
    }

}
