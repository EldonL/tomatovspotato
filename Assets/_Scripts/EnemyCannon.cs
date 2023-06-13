using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : EnemyBase
{
    [SerializeField] private Transform bombTransform;
    public WaitForSeconds shootBombSeconds = new WaitForSeconds(2.0f);
    protected override void CollideWithPlayer()
    {

        //nothing yet
    }

    protected override IEnumerator EnabledEnemy()
    {
        yield return shootBombSeconds;
        while (true)
        {
            GameObject enemy = EnemyPoolInstance.Instance.GetPooledObjectA();
            enemy.transform.position = bombTransform.position;
            enemy.transform.rotation = bombTransform.rotation;
            enemy.gameObject.SetActive(true);
            yield return shootBombSeconds;
        }

    }
}
