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
        ScoreManager.LevelIncreaseEvent += Level2;
    }

    private void OnDestroy()
    {
        ScoreManager.LevelIncreaseEvent -= Level2;
        Instance = null;
    }

    private void Level2()
    {
        if (ScoreManager.Instance.LevelInt==2)
        {
            ScoreManager.LevelIncreaseEvent -= Level2;
            foreach (var enemies in enemiesList)
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
            foreach (var enemies in enemiesList)
            {
                if(!enemies.gameObject.activeInHierarchy)
                {
                    numberOfEnemiesDisabled++;
                    if(numberOfEnemiesDisabled==enemiesList.Count)
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
