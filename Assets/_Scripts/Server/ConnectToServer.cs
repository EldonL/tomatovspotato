using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using TMPro;
public class ConnectToServer : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField _usernameInput;
    [SerializeField] private TextMeshProUGUI buttonText;


    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        SceneManager.LoadScene("Lobby");
    }


    public void OnClickConnect()
    {
        if(_usernameInput.text.Length>=1)
        {
            PhotonNetwork.NickName = _usernameInput.text;
            buttonText.text = "Connecting...";
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

}
