using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Enemy : EnemyBase
{
    protected override void CollideWithPlayer()
    {
        //nothing
    }

    protected override IEnumerator EnabledEnemy()
    {
        if (!view.IsMine)
            yield break;
        else
        {
            yield return timeToStayEnabled;
            PhotonNetwork.Destroy(gameObject);

        }
        yield break;
    }
}
