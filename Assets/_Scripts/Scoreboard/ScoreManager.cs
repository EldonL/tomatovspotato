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

    public static ScoreManager Instance;
    public void Awake()
    {
        Instance = this;
        playerListEntries = new Dictionary<int, GameObject>();

        foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerList)
        {
            GameObject entry = Instantiate(_playerOverviewEntryPrefab);
            entry.transform.SetParent(_playerOverviewEntrySpawnPosition.transform);
            entry.transform.localScale = Vector3.one;
            var playerTextInformationComponent = entry.GetComponent<PlayerTextInformation>();
            playerTextInformationComponent.Coins = p.GetCoin().ToString();
            playerTextInformationComponent.Score = p.GetScore().ToString();
            playerTextInformationComponent.NickName = p.NickName;
            playerTextInformationComponent.Lives = TomatoGame.PLAYER_MAX_LIVES.ToString();
            playerListEntries.Add(p.ActorNumber, entry);
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    public void AddCoinToPlayer(Photon.Realtime.Player targetPlayer, int coins)
    {
        //GameObject entry;
        //if (playerListEntries.TryGetValue(targetPlayer.ActorNumber, out entry))
        //{
        //    var playerTextInformationComponent = entry.GetComponent<PlayerTextInformation>();
        //    playerTextInformationComponent.Coins = coins.ToString();

        //}
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        GameObject entry;
        if (playerListEntries.TryGetValue(targetPlayer.ActorNumber, out entry))
        {
            var playerTextInformationComponent = entry.GetComponent<PlayerTextInformation>();
            playerTextInformationComponent.Coins = targetPlayer.GetCoin().ToString();
            playerTextInformationComponent.Score = targetPlayer.GetScore().ToString();
            playerTextInformationComponent.Lives = targetPlayer.CustomProperties[TomatoGame.PLAYER_LIVES].ToString();
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
