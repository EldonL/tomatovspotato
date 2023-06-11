using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ScoreManager Instance;
    [SerializeField] private PlayerScores player1;
    [SerializeField] private PlayerScores player2;



    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

    }

    private void Start()
    {
        
    }
}
