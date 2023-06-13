using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonSpawnerInstance : MonoBehaviour
{

    public static EnemyCannonSpawnerInstance Instance;
    [SerializeField] private List<EnemyBase> enemiesList2 = new List<EnemyBase>();
    [SerializeField] private List<EnemyBase> enemiesList3 = new List<EnemyBase>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        foreach (var enemies in enemiesList2)
        {
            enemies.gameObject.SetActive(false);
        } 
        foreach (var enemies in enemiesList3)
        {
            enemies.gameObject.SetActive(false);
        }
        ScoreManager.LevelIncreaseEvent += Level2;
        ScoreManager.LevelIncreaseEvent += Level3;
    }

    private void OnDestroy()
    {
        ScoreManager.LevelIncreaseEvent -= Level2;
        ScoreManager.LevelIncreaseEvent -= Level3;
        Instance = null;
    }

    private void Level2()
    {
        if (ScoreManager.Instance.LevelInt==2)
        {
            ScoreManager.LevelIncreaseEvent -= Level2;
            foreach (var enemies in enemiesList2)
            {
                enemies.gameObject.SetActive(true);
            }
            StartCoroutine(Level2Routine());
        }

    }

    private IEnumerator Level2Routine()
    {
        while(true)
        {
            int numberOfEnemiesDisabled = 0;
            foreach (var enemies in enemiesList2)
            {
                if(!enemies.gameObject.activeInHierarchy)
                {
                    numberOfEnemiesDisabled++;
                    if(numberOfEnemiesDisabled==enemiesList2.Count)
                    {
                        ScoreManager.Instance.AddLevel();
                        yield break;
                    }
                    yield return null;
                }
                yield return null;
            }

        }

    }

    private void Level3()
    {
        if (ScoreManager.Instance.LevelInt == 3)
        {
            ScoreManager.LevelIncreaseEvent -= Level3;
            foreach (var enemies in enemiesList3)
            {
                enemies.gameObject.SetActive(true);
            }
            StartCoroutine(Level3Routine());
        }
    }

    private IEnumerator Level3Routine()
    {
        while (true)
        {
            int numberOfEnemiesDisabled = 0;
            foreach (var enemies in enemiesList3)
            {
                if (!enemies.gameObject.activeInHierarchy)
                {
                    numberOfEnemiesDisabled++;
                    if (numberOfEnemiesDisabled == enemiesList3.Count)
                    {
                        ScoreManager.Instance.AddLevel();
                        yield break;
                    }
                    yield return null;
                }
                yield return null;
            }

        }

    }
}
