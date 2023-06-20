using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    private void Awake()
    {
        PhotonNetwork.Instantiate(_playerPrefab.name, transform.position, transform.rotation);
    }
}
