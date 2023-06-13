using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] private PlayerScores player1;
    [SerializeField] private PlayerScores player2;


    public delegate void ScoreManagerAction();
    public static event ScoreManagerAction NoLivesEvent;

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

    private void OnDestroy()
    {
        Instance = null;
    }
    public void AddCoin(GameManager.PlayerType playerType, int coins)
    {
        switch(playerType)
        {
            case GameManager.PlayerType.p1:
                player1.Coin += coins;
                break;
            case GameManager.PlayerType.p2:
                player2.Coin += coins;
                break;
        }
    }

    public void AddScore(GameManager.PlayerType playerType, int scores)
    {
        switch (playerType)
        {
            case GameManager.PlayerType.p1:
                player1.Score += scores;
                break;
            case GameManager.PlayerType.p2:
                player2.Score += scores;
                break;
        }
    }

    public void AddLives(GameManager.PlayerType playerType, int lives)
    {
        switch (playerType)
        {
            case GameManager.PlayerType.p1:
                player1.Lives += lives;
                break;
            case GameManager.PlayerType.p2:
                player2.Lives += lives;
                break;
        }
    }

    public void MinusLives(GameManager.PlayerType playerType, int lives)
    {
        switch (playerType)
        {
            case GameManager.PlayerType.p1:
                player1.Lives -= lives;
                break;
            case GameManager.PlayerType.p2:
                player2.Lives -= lives;
                break;
        }
        
        // need to do a check if one player game
        if(player1.Lives<=0)
        {
            NoLivesEvent?.Invoke();
        }
        // need to do a  check if two player game
        if (player1.Lives<=0 && player2.Lives<=0)
        {
            NoLivesEvent?.Invoke();
        }
    }

}
