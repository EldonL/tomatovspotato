using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPoolInstance : MonoBehaviourPunCallbacks
{

    public static CoinPoolInstance Instance;

    [SerializeField] private Transform startLocationA;
    [SerializeField] private Transform startLocationB;
    [SerializeField] private GameObject coinA;
    [SerializeField] private GameObject coinB;
    [SerializeField] private GameObject coinC;

    public Transform CoinTextSpawnAboveOtherUI { get => coinTextSpawnAboveOtherUI; }
    [SerializeField] private Transform coinTextSpawnAboveOtherUI;

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
            StartCoroutine(SpawnCoinA());
            StartCoroutine(SpawnCoinB());
            StartCoroutine(SpawnCoinC());
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    private IEnumerator SpawnCoinA()
    {
        while (true)
        {
            yield return new WaitForSeconds(TomatoGame.COINA_SPAWN_TIME);
            var x = Random.Range(startLocationA.position.x, startLocationB.position.x);
            var y = startLocationA.position.y;
            var z = startLocationA.position.z;
            Vector3 spawnPosition = new Vector3(x, y, z);
            PhotonNetwork.Instantiate(coinA.name, spawnPosition, startLocationA.rotation);
        }
    }
    
    private IEnumerator SpawnCoinB()
    {
        while (true)
        {
            yield return new WaitForSeconds(TomatoGame.COINB_SPAWN_TIME);
            var x = Random.Range(startLocationA.position.x, startLocationB.position.x);
            var y = startLocationA.position.y;
            var z = startLocationA.position.z;
            Vector3 spawnPosition = new Vector3(x, y, z);
            PhotonNetwork.Instantiate(coinB.name, spawnPosition, startLocationA.rotation);
        }
    }
    
    private IEnumerator SpawnCoinC()
    {
        while (true)
        {
            yield return new WaitForSeconds(TomatoGame.COINC_SPAWN_TIME);
            var x = Random.Range(startLocationA.position.x, startLocationB.position.x);
            var y = startLocationA.position.y;
            var z = startLocationA.position.z;
            Vector3 spawnPosition = new Vector3(x, y, z);
            PhotonNetwork.Instantiate(coinC.name, spawnPosition, startLocationA.rotation);
        }
    }

    #region PUNCALLBACKS
    public override void OnMasterClientSwitched(Photon.Realtime.Player newMasterClient)
    {
        Debug.Log($"onmasterclientswitched entered- localplayeractornumber:{PhotonNetwork.LocalPlayer.ActorNumber} and newmasterclient.actornumber {newMasterClient.ActorNumber}");
        if (PhotonNetwork.LocalPlayer.ActorNumber == newMasterClient.ActorNumber)
        {
            StartCoroutine(SpawnCoinA());
            StartCoroutine(SpawnCoinB());
            StartCoroutine(SpawnCoinC());
        }
    }
    #endregion


}
