using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{
    protected override void CollideWithPlayer()
    {
        //nothing
    }

    protected override IEnumerator EnabledEnemy()
    {
        if (gameObject.activeInHierarchy)
        {
            yield return timeToStayEnabled;
            gameObject.SetActive(false);
        }
        else
            yield break;
    }
}
