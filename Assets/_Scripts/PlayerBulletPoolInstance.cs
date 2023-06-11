using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPoolInstance : MonoBehaviour
{
    public static PlayerBulletPoolInstance Instance;
    public List<GameObject> pooledObjects;
    [SerializeField]private GameObject _objectToPool;
    private int _amountToPool =40;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i =0; i<_amountToPool; i++)
        {
            tmp = Instantiate(_objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i =0; i<_amountToPool; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
