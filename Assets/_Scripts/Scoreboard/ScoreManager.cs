using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class ScoreManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _playerOverviewEntryPrefab;
    [SerializeField] private GameObject _playerOverviewEntrySpawnPosition;

    private Dictionary<int, GameObject> playerListEntries;

    [SerializeField] private TextMeshProUGUI levelText;
    public int LevelInt { get => levelInt; private set => levelInt = value; }
    private int levelInt;

    public delegate void ScoreManagerAction();
    public static event ScoreManagerAction NoLivesEvent;

    public delegate void ScoreManagerLevelIncreaseAction();
    public static event ScoreManagerLevelIncreaseAction LevelIncreaseEvent;

    public void Awake()
    {
        playerListEntries = new Dictionary<int, GameObject>();

        foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerList)
        {
            GameObject entry = Instantiate(_playerOverviewEntryPrefab);
            entry.transform.SetParent(_playerOverviewEntrySpawnPosition.transform);
            entry.transform.localScale = Vector3.one;

            entry.GetComponent<PlayerTextInformation>().Coins = p.GetCoin().ToString();
            entry.GetComponent<PlayerTextInformation>().Score = p.GetScore().ToString();

            playerListEntries.Add(p.ActorNumber, entry);
        }
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        GameObject entry;
        if (playerListEntries.TryGetValue(targetPlayer.ActorNumber, out entry))
        {
            entry.GetComponent<PlayerTextInformation>().Coins = targetPlayer.GetCoin().ToString();
            entry.GetComponent<PlayerTextInformation>().Score = targetPlayer.GetScore().ToString();
        }
    }

    //public void AddLevel()
    //{
    //    levelInt += 1;
    //    levelText.text = levelInt.ToString();
    //    LevelIncreaseEvent?.Invoke();
    //}

    //public void AddCoin(GameManager.PlayerType playerType, int coins)
    //{
    //    switch(playerType)
    //    {
    //        case GameManager.PlayerType.p1:
    //            player1.Coin += coins;
    //            break;
    //        case GameManager.PlayerType.p2:
    //            player2.Coin += coins;
    //            break;
    //    }
    //}

    //public void AddScore(GameManager.PlayerType playerType, int scores)
    //{
    //    switch (playerType)
    //    {
    //        case GameManager.PlayerType.p1:
    //            player1.Score += scores;
    //            break;
    //        case GameManager.PlayerType.p2:
    //            player2.Score += scores;
    //            break;
    //    }
    //}

    //public void AddLives(GameManager.PlayerType playerType, int lives)
    //{
    //    switch (playerType)
    //    {
    //        case GameManager.PlayerType.p1:
    //            player1.Lives += lives;
    //            break;
    //        case GameManager.PlayerType.p2:
    //            player2.Lives += lives;
    //            break;
    //    }
    //}

    //public void MinusLives(GameManager.PlayerType playerType, int lives)
    //{
    //    switch (playerType)
    //    {
    //        case GameManager.PlayerType.p1:
    //            player1.Lives -= lives;
    //            break;
    //        case GameManager.PlayerType.p2:
    //            player2.Lives -= lives;
    //            break;
    //    }
        
    //    // need to do a check if one player game
    //    if(player1.Lives<=0)
    //    {
    //        NoLivesEvent?.Invoke();
    //    }
    //    // need to do a  check if two player game
    //    if (player1.Lives<=0 && player2.Lives<=0)
    //    {
    //        NoLivesEvent?.Invoke();
    //    }
    //}

}
