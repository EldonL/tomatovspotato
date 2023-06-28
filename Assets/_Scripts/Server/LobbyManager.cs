using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public TextMeshProUGUI roomName;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.JoinLobby();
        roomPanel.SetActive(false);
    }

    public void OnClickCreate()
    {
        if(roomInputField.text.Length>=1)
        {
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions() { MaxPlayers = 2 }) ;
        }
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room name: " + PhotonNetwork.CurrentRoom.Name;
    }

}
