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
    protected PhotonView view;
    public void Awake()
    {
        playerListEntries = new Dictionary<int, GameObject>();
        view = GetComponent<PhotonView>();
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


    public void AddLevel()
    { 
        view.RPC("AddLevelRPC", RpcTarget.All);
    }

    [PunRPC]
    public void AddLevelRPC()
    {
        levelInt += 1;
        levelText.text = levelInt.ToString();
        LevelIncreaseEvent?.Invoke();
    }

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.A))
    //    {
    //        AddLevel();
    //    }
    //}


}
