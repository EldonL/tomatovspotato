using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPoolInstance : MonoBehaviour
{
    public static PlayerBulletPoolInstance Instance;
    public List<Bullet> pooledObjects;
    [SerializeField]private Bullet _objectToPool;
    private int _amountToPool =40;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<Bullet>();
        Bullet tmp;
        for(int i =0; i<_amountToPool; i++)
        {
            tmp = Instantiate(_objectToPool);
            tmp.gameObject.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public Bullet GetPooledObject()
    {
        for(int i =0; i<_amountToPool; i++)
        {
            if(!pooledObjects[i].gameObject.activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
