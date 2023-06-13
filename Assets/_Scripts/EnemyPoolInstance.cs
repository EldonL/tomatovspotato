using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolInstance : MonoBehaviour
{
    public static EnemyPoolInstance Instance;

    public List<GameObject> pooledObjectsA;
    public List<GameObject> pooledObjectsB;
    public List<GameObject> pooledObjectsC;
    [SerializeField] private GameObject _objectToPoolA;
    [SerializeField] private GameObject _objectToPoolB;
    [SerializeField] private GameObject _objectToPoolC;
    private int _amountToPool = 40;

    private int numberOfEnemyASpawned;
    private int numberOfEnemyAToSpawn =5;
    private bool enemyASpawnedDone = false;
    public enum enemyType
    {
        enemyA,
        enemyB,
        enemyC
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
        GameObject tmpA;
        GameObject tmpB;
        GameObject tmpC;
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
    }

    public GameObject GetPooledObjectA()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            if (!pooledObjectsA[i].gameObject.activeInHierarchy)
            {
                numberOfEnemyASpawned++;
                if (numberOfEnemyASpawned > numberOfEnemyAToSpawn && !enemyASpawnedDone)
                {
                    ScoreManager.Instance.AddLevel();
                    enemyASpawnedDone = true;
                }
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

    private void OnDestroy()
    {
        Instance = null;
    }
}
