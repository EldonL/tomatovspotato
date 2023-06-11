using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CoinSpawn : MonoBehaviour
{
    private float _timer = 0.0f;
    [SerializeField] private float _timerToReloadBullet = 0.2f;

    [SerializeField] private CoinPoolInstance.coinType coinType;
    // Start is called before the first frame update
    [SerializeField] private Transform startLocationA;
    [SerializeField] private Transform startLocationB;
    void Start()
    {
        transform.DOMoveX(startLocationB.position.x, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _timerToReloadBullet)
        {
            CoinSelection();
            _timer = 0.0f;
        }


    }

    private void CoinSelection()
    {
        switch(coinType)
        {
            case CoinPoolInstance.coinType.coinA:
                GameObject coinA = CoinPoolInstance.Instance.GetPooledObjectA();
                SpawnCoin(coinA);
                break;
            case CoinPoolInstance.coinType.coinB:
                GameObject coinB = CoinPoolInstance.Instance.GetPooledObjectB();
                SpawnCoin(coinB);
                break;
            case CoinPoolInstance.coinType.coinC:
                GameObject coinC = CoinPoolInstance.Instance.GetPooledObjectC();
                SpawnCoin(coinC);
                break;
        }
    }

    private void SpawnCoin(GameObject coin)
    {
        if (coin != null)
        {
            coin.transform.position = transform.position;
            coin.transform.rotation = transform.rotation;
            coin.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="coinPointA")
        {
            transform.DOMoveX(startLocationB.position.x, 2.0f);
        }
        if (collision.gameObject.tag == "coinPointB")
        {
            transform.DOMoveX(startLocationA.position.x, 2.0f);
        }
    }
}
