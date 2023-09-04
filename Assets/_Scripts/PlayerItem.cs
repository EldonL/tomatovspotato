using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
public class PlayerItem : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI playerName;

    [SerializeField] private GameObject leftArrowButton;
    [SerializeField] private GameObject rightArrowButton;
    [SerializeField] private UnityEngine.UI.Button playerReadyButton;
    [SerializeField] private TextMeshProUGUI playerReadyText;
    private bool isPlayerReady;
    private int actorNumber;

    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    public UnityEngine.UI.Image playerAvatar;
    public Sprite[] avatars;

    Photon.Realtime.Player player;

    private void Start()
    {
        if(PhotonNetwork.LocalPlayer.ActorNumber != actorNumber)
        {
            leftArrowButton.SetActive(false);
            rightArrowButton.SetActive(false);
            playerReadyButton.gameObject.SetActive(false);
        }
        else
        {
            ExitGames.Client.Photon.Hashtable initialProps =
    new ExitGames.Client.Photon.Hashtable() { { TomatoGame.PLAYER_READY, isPlayerReady }, { TomatoGame.PLAYER_LIVES, TomatoGame.PLAYER_MAX_LIVES } };
            PhotonNetwork.LocalPlayer.SetCustomProperties(initialProps);
            PhotonNetwork.LocalPlayer.SetScore(0);
            PhotonNetwork.LocalPlayer.SetCoin(0);


            playerReadyButton.onClick.AddListener(OnReadyButtonClicked);
        }

        
    }
    public void SetPlayerInfo(Photon.Realtime.Player _player)
    {
        playerName.text = _player.NickName;
        player = _player;
        actorNumber = _player.ActorNumber;
        UpdatePlayerItem(player);
    }


    public void OnClickLeftArrow()
    {
        if ((int)playerProperties["playerAvatar"] == 0)
        {
            playerProperties["playerAvatar"] = avatars.Length - 1;
        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] - 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public void OnClickRightArrow()
    {
        if ((int)playerProperties["playerAvatar"] == avatars.Length - 1)
        {
            playerProperties["playerAvatar"] = 0;
        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] + 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);
        if(player==targetPlayer)
        {
            UpdatePlayerItem(targetPlayer);
        }
    }

    private void UpdatePlayerItem(Photon.Realtime.Player player)
    {
        if(player.CustomProperties.ContainsKey("playerAvatar"))
        {
            playerAvatar.sprite = avatars[(int)player.CustomProperties["playerAvatar"]];
            playerProperties["playerAvatar"] = (int)player.CustomProperties["playerAvatar"];
        }
        else
        {
            playerProperties["playerAvatar"] = 0;
        }
        object isThePlayerReady;
        if (player.CustomProperties.TryGetValue(TomatoGame.PLAYER_READY, out isThePlayerReady))
        {
            SetPlayerReady((bool)isThePlayerReady);
            Debug.Log("hi");
        }

    }

    private void OnReadyButtonClicked()
    {
        isPlayerReady = !isPlayerReady;
        SetPlayerReady(isPlayerReady);

        ExitGames.Client.Photon.Hashtable props = new ExitGames.Client.Photon.Hashtable() { { TomatoGame.PLAYER_READY, isPlayerReady }};
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);

        if(PhotonNetwork.IsMasterClient)
        {
            FindObjectOfType<LobbyManager>().LocalPlayerPropertiesUpdated();
        }
    }

    public void SetPlayerReady(bool playerReady)
    {
        playerReadyText.text = playerReady ? "Let's play!" : "Ready?";

    }
}
