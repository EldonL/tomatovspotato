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
    [SerializeField] private TextMeshProUGUI errorText;
    [SerializeField] private UnityEngine.UI.Button connectButton;

    private void Awake()
    {
        errorText.gameObject.SetActive(false);
    }
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
            connectButton.interactable = false;
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            errorText.gameObject.SetActive(true);
            errorText.text = "Enter name";
        }
    }



}
