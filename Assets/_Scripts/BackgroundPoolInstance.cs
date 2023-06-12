using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPoolInstance : MonoBehaviour
{
    public static BackgroundPoolInstance Instance;
    public Transform backgroundStartPoint;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instance = null;
    }

}
