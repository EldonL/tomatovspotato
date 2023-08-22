using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance;
    private string mainMenuScene = "MainMenuScene";

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    #region PUN CALLBACKS

    public override void OnDisconnected(Photon.Realtime.DisconnectCause cause)
    {
        base.OnDisconnected(cause);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuScene);
    }

    public override void OnMasterClientSwitched(Photon.Realtime.Player newMasterClient)
    {
        base.OnMasterClientSwitched(newMasterClient);
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
    }


    #endregion

}
