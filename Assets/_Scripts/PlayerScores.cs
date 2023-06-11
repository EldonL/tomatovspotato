using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerScores : MonoBehaviour
{

    private int defaultLives = 3;
    private int defaultCoins = 0;
    private int defaultScore = 0;
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            _scoreText.text = _score.ToString();          
        }
    }

    public int Coin
    {
        get => _coin;
        set
        {
            _coin = value;
            _coinText.text = _coin.ToString();
        }
    }

    public int Lives
    {
        get => _lives;
        set
        {
            _lives = value;
            _livesText.text = _lives.ToString();
        }
    }

    private int _score;
    private int _coin;
    private int _lives;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private TextMeshProUGUI _livesText;

    private void Start()
    {
        Coin = defaultCoins;
        Lives = defaultLives;
        Score = defaultScore;
    }
}
