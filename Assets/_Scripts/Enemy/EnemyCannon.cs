using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Photon.Pun;

public class EnemyCannon : EnemyBase
{
    [SerializeField] private Transform bombTransform;
    public WaitForSeconds shootBombSeconds = new WaitForSeconds(2.0f);
    [SerializeField] private Transform endPoint;
    [SerializeField] private bool allowMoveAtStart = false;
    [SerializeField] private GameObject smallPotatoEnemy;

    protected override void CollideWithPlayer()
    {

        //nothing yet
    }

    public override void OnEnable()
    {
        base.OnEnable();
        if(view.IsMine)
        {
            if (allowMoveAtStart)
                transform.DOMoveY(endPoint.position.y, 1f);
        }
    }

    protected override IEnumerator EnabledEnemy()
    {
        if (!view.IsMine)
        {
            yield break;
        }
        else
        {
            yield return shootBombSeconds;
            while (true)
            {
                PhotonNetwork.InstantiateRoomObject(smallPotatoEnemy.name, bombTransform.position, bombTransform.rotation);

                yield return shootBombSeconds;
            }
        }


    }
}
