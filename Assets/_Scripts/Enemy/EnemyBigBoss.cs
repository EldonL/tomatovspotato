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

    public override void OnEnable()
    {
        base.OnEnable();
        if(view.IsMine)
        {
            transform.DOMoveY(endPoint.position.y, 1f);
        }

    }

    protected override IEnumerator EnabledEnemy()
    {
        yield break;

    }
}
