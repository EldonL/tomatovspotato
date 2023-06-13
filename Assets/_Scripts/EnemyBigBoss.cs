using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigBoss : EnemyBase
{
    protected override void CollideWithPlayer()
    {
        
    }

    protected override IEnumerator EnabledEnemy()
    {
        yield break;
    }
}
