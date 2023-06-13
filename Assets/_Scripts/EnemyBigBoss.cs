using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyBigBoss : EnemyBase
{
    [SerializeField] private Transform endPoint;
    protected override void CollideWithPlayer()
    {

        //nothing yet
    }

    protected override IEnumerator EnabledEnemy()
    {
        transform.DOMoveY(endPoint.position.y, 2f);
        yield break;
    }
}
