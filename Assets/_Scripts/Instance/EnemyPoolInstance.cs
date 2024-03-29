using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class EnemyPoolInstance : MonoBehaviourPunCallbacks
{
    public static EnemyPoolInstance Instance;

    [SerializeField] private Transform startLocationA;
    [SerializeField] private Transform startLocationB;
    [SerializeField] private GameObject smallPotatoEnemy;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(SpawnSmallPotatoEnemy());           

        }           
    }
    private void OnDestroy()
    {
        Instance = null;
    }

    private IEnumerator SpawnSmallPotatoEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(TomatoGame.POTATO_ENEMY_MIN_SPAWN_TIME, TomatoGame.POTATO_ENEMY_MAX_SPAWN_TIME));
            var x = Random.Range(startLocationA.position.x, startLocationB.position.x);
            var y = startLocationA.position.y;
            var z = startLocationA.position.z;
            Vector3 spawnPosition = new Vector3(x, y, z);
            PhotonNetwork.InstantiateRoomObject(smallPotatoEnemy.name, spawnPosition, startLocationA.rotation);
        }
    }

    #region PUNCALLBACKS
    public override void OnMasterClientSwitched(Photon.Realtime.Player newMasterClient)
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == newMasterClient.ActorNumber)
        {
            StartCoroutine(SpawnSmallPotatoEnemy());
        }
    }
    #endregion
}
