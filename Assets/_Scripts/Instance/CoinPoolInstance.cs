using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPoolInstance : MonoBehaviour
{

    public static CoinPoolInstance Instance;

    public List<GameObject> pooledObjectsA;
    public List<GameObject> pooledObjectsB;
    public List<GameObject> pooledObjectsC;
    public List<GameObject> pooledCoinText;
    [SerializeField] private GameObject _objectToPoolA;
    [SerializeField] private GameObject _objectToPoolB;
    [SerializeField] private GameObject _objectToPoolC;
    [SerializeField] private GameObject _objectCoinText;
    private int _amountToPool = 5;
    private int _amountToPoolCoinText = 3;

    [SerializeField] private GameObject coinTextSpawnAboveOtherUI;
    public enum coinType
    {
        coinA,
        coinB,
        coinC
    }
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
        pooledObjectsA = new List<GameObject>();
        pooledObjectsB = new List<GameObject>();
        pooledObjectsC = new List<GameObject>();
        pooledCoinText = new List<GameObject>();
        GameObject tmpA;
        GameObject tmpB;
        GameObject tmpC;
        GameObject tmpCoinText;
        for (int i = 0; i < _amountToPool; i++)
        {
            tmpA = Instantiate(_objectToPoolA);
            tmpA.gameObject.SetActive(false);
            pooledObjectsA.Add(tmpA);
        }
        for (int i = 0; i < _amountToPool; i++)
        {
            tmpB = Instantiate(_objectToPoolB);
            tmpB.gameObject.SetActive(false);
            pooledObjectsB.Add(tmpB);
        }
        for (int i = 0; i < _amountToPool; i++)
        {
            tmpC = Instantiate(_objectToPoolC);
            tmpC.gameObject.SetActive(false);
            pooledObjectsC.Add(tmpC);
        }
        for (int i = 0; i < _amountToPoolCoinText; i++)
        {
            tmpCoinText = Instantiate(_objectCoinText,coinTextSpawnAboveOtherUI.transform);
            tmpCoinText.gameObject.SetActive(false);
            pooledCoinText.Add(tmpCoinText);
        }
    }

    public GameObject GetPooledObjectA()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            if (!pooledObjectsA[i].gameObject.activeInHierarchy)
            {
                return pooledObjectsA[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObjectB()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            if (!pooledObjectsB[i].gameObject.activeInHierarchy)
            {
                return pooledObjectsB[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObjectC()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            if (!pooledObjectsC[i].gameObject.activeInHierarchy)
            {
                return pooledObjectsC[i];
            }
        }
        return null;
    }
    
    public GameObject GetPooledCoinText()
    {
        for (int i = 0; i < _amountToPoolCoinText; i++)
        {
            if (!pooledCoinText[i].gameObject.activeInHierarchy)
            {
                return pooledCoinText[i];
            }
        }
        return null;
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
