using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPoolInstance : MonoBehaviour
{
    public static BackgroundPoolInstance Instance;
    public Transform backgroundStartPoint;
    [SerializeField] private List<Sprite> spriteRenderer = new List<Sprite>();
    [SerializeField] private List<Background> background = new List<Background>();
    int spriteIndex = 0;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        EnemyPoolInstance.EnemyASpawnedEvent += BackGroundToUse;
    }

    private void OnDestroy()
    {
        EnemyPoolInstance.EnemyASpawnedEvent -= BackGroundToUse;
        Instance = null;
    }

    private void BackGroundToUse()
    {
        spriteIndex++;
        if (spriteRenderer.Count < spriteIndex)
            spriteIndex = 0;
        foreach(var bg in background)
        {
            bg.spriteRenderer.sprite = spriteRenderer[spriteIndex];
        }
    }

}
