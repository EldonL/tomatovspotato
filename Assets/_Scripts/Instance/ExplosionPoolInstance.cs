using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPoolInstance : MonoBehaviour
{

    public static ExplosionPoolInstance Instance;
    public List<GameObject> pooledObjectsA;
    [SerializeField] private GameObject _objectToPoolA;
    private int _amountToPool = 6;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        pooledObjectsA = new List<GameObject>();

        GameObject tmpA;

        for (int i = 0; i < _amountToPool; i++)
        {
            tmpA = Instantiate(_objectToPoolA);
            tmpA.gameObject.SetActive(false);
            pooledObjectsA.Add(tmpA);
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
}
