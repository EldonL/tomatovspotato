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

    protected override IEnumerator EnabledEnemy()
    {
        if (!view.IsMine)
        {
            yield break;
        }
        else
        {
            if (allowMoveAtStart)              
                transform.DOMoveY(endPoint.position.y, 1f);
            yield return shootBombSeconds;
            while (true)
            {
                PhotonNetwork.Instantiate(smallPotatoEnemy.name, bombTransform.position, bombTransform.rotation);

                yield return shootBombSeconds;
            }
        }


    }
}
