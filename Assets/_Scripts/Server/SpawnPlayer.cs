using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _masterSpawnTransform;
    [SerializeField] private Transform _clientSpawnTransform;


    private void Awake()
    {
        GameObject newPlayer;
        if (PhotonNetwork.IsMasterClient)
        {
            newPlayer = PhotonNetwork.Instantiate(_playerPrefab.name, _masterSpawnTransform.position, _masterSpawnTransform.rotation);
        }

        else
            newPlayer = PhotonNetwork.Instantiate(_playerPrefab.name, _clientSpawnTransform.position, _clientSpawnTransform.rotation);

        foreach (KeyValuePair<int, Photon.Realtime.Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            if (player.Value == PhotonNetwork.LocalPlayer)
            {
                var newPlayerPlayerComponent = newPlayer.GetComponent<Player>();
                newPlayerPlayerComponent.SetPlayerInfo(player.Value);
            }
        }
    }
}
