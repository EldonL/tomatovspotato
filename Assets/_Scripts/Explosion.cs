using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float timeBeforeDestroy = 1.0f;

    private void Start()
    {
        Destroy(gameObject, timeBeforeDestroy);
    }

}
