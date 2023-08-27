using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;
public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject _root;
    [SerializeField] private Button _quitButton;
    [SerializeField] private string quitToMainScene = "MainMenuScene";
    [SerializeField] private Transform playerOverviewSpawnPosition;
    [SerializeField] private GameObject playerOverviewEntryPrefab;

    private void Awake()
    {
        _quitButton.onClick.AddListener(QuitButtonClick);
        _root.SetActive(false);
        ScoreManager.NoLivesEvent += NoLives;
    }

    private void OnDestroy()
    {
        _quitButton.onClick.RemoveAllListeners();
        ScoreManager.NoLivesEvent -= NoLives;
    }

    private void QuitButtonClick()
    {
        Time.timeScale = 1.0f;
        PhotonNetwork.Disconnect();
    }

    private void NoLives()
    {
        Time.timeScale = 0.0f;
        foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerList)
        {
            GameObject entry = Instantiate(playerOverviewEntryPrefab, playerOverviewSpawnPosition);
            //entry.transform.SetParent(playerOverviewSpawnPosition);
            var playerTextInformationComponent = entry.GetComponent<PlayerTextInformation>();
            playerTextInformationComponent.Coins = p.GetCoin().ToString();
            playerTextInformationComponent.Score = p.GetScore().ToString();
            playerTextInformationComponent.NickName = p.NickName;
            //playerTextInformationComponent.Lives = TomatoGame.PLAYER_MAX_LIVES.ToString();
        }

        _root.SetActive(true);
    }

}
