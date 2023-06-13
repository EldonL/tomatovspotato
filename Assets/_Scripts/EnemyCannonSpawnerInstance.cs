using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonSpawnerInstance : MonoBehaviour
{

    public static EnemyCannonSpawnerInstance Instance;
    [SerializeField] private List<EnemyBase> enemiesList = new List<EnemyBase>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        foreach (var enemies in enemiesList)
        {
            enemies.gameObject.SetActive(false);
        }
        EnemyPoolInstance.EnemyASpawnedEvent += Level2;
    }

    private void OnDestroy()
    {
        EnemyPoolInstance.EnemyASpawnedEvent -= Level2;
        Instance = null;
    }

    private void Level2()
    {
        foreach (var enemies in enemiesList)
        {
            enemies.gameObject.SetActive(true);
        }
    }

}
