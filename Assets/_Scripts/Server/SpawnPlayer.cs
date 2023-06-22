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
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.Instantiate(_playerPrefab.name, _masterSpawnTransform.position, _masterSpawnTransform.rotation);
        else
            PhotonNetwork.Instantiate(_playerPrefab.name, _clientSpawnTransform.position, _masterSpawnTransform.rotation);
    }
}
