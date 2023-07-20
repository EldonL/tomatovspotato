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
        if (!view.IsMine)
        {
            yield break;
        }
        else
        {
            transform.DOMoveY(endPoint.position.y, 1f);
            yield break;
        }

    }
}
