using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemySpawn : MonoBehaviour
{
    private float _timer = 0.0f;
    [SerializeField] private float _timerToReloadBullet = 0.2f;

    [SerializeField] private EnemyPoolInstance.enemyType enemyType;
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
            EnemySelection();
            _timer = 0.0f;
        }


    }

    private void EnemySelection()
    {
        switch (enemyType)
        {
            case EnemyPoolInstance.enemyType.enemyA:
                GameObject enemyA = EnemyPoolInstance.Instance.GetPooledObjectA();
                SpawnEnemy(enemyA);
                break;
            case EnemyPoolInstance.enemyType.enemyB:
                GameObject enemyB = EnemyPoolInstance.Instance.GetPooledObjectB();
                SpawnEnemy(enemyB);
                break;
            case EnemyPoolInstance.enemyType.enemyC:
                GameObject enemyC = EnemyPoolInstance.Instance.GetPooledObjectC();
                SpawnEnemy(enemyC);
                break;
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        if (enemy != null)
        {
            enemy.transform.position = transform.position;
            enemy.transform.rotation = transform.rotation;
            enemy.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coinPointA")
        {
            transform.DOMoveX(startLocationB.position.x, 2.0f);
        }
        if (collision.gameObject.tag == "coinPointB")
        {
            transform.DOMoveX(startLocationA.position.x, 2.0f);
        }
    }
}
