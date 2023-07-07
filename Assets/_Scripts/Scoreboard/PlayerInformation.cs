using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInformation : MonoBehaviour
{
    public const string PlayerScoreProp = "score";
    public const string PlayerCoinProp = "coin";
}

public static class PlayerScoresExtensions
{
    public static void SetScore(this Photon.Realtime.Player player, int newScore)
    {
        ExitGames.Client.Photon.Hashtable score = new ExitGames.Client.Photon.Hashtable();  // using PUN's implementation of Hashtable
        score[PlayerInformation.PlayerScoreProp] = newScore;

        player.SetCustomProperties(score);  // this locally sets the score and will sync it in-game asap.
    }

    public static void SetCoin(this Photon.Realtime.Player player, int newCoin)
    {
        ExitGames.Client.Photon.Hashtable coin = new ExitGames.Client.Photon.Hashtable();  // using PUN's implementation of Hashtable
        coin[PlayerInformation.PlayerCoinProp] = newCoin;

        player.SetCustomProperties(coin);  // this locally sets the coin and will sync it in-game asap.
    }

    public static void AddScore(this Photon.Realtime.Player player, int scoreToAddToCurrent)
    {
        int current = player.GetScore();
        current = current + scoreToAddToCurrent;

        ExitGames.Client.Photon.Hashtable score = new ExitGames.Client.Photon.Hashtable();  // using PUN's implementation of Hashtable
        score[PlayerInformation.PlayerScoreProp] = current;

        player.SetCustomProperties(score);  // this locally sets the score and will sync it in-game asap.
    }
    
    public static void AddCoin(this Photon.Realtime.Player player, int coinToAddToCurrent)
    {
        int current = player.GetCoin();
        current = current + coinToAddToCurrent;

        ExitGames.Client.Photon.Hashtable coin = new ExitGames.Client.Photon.Hashtable();  // using PUN's implementation of Hashtable
        coin[PlayerInformation.PlayerCoinProp] = current;

        player.SetCustomProperties(coin);  // this locally sets the coin and will sync it in-game asap.
    }

    public static int GetScore(this Photon.Realtime.Player player)
    {
        object score;
        if (player.CustomProperties.TryGetValue(PlayerInformation.PlayerScoreProp, out score))
        {
            return (int)score;
        }

        return 0;
    }

    public static int GetCoin(this Photon.Realtime.Player player)
    {
        object coin;
        if (player.CustomProperties.TryGetValue(PlayerInformation.PlayerCoinProp, out coin))
        {
            return (int)coin;
        }

        return 0;
    }
    //private int defaultLives = 3;
    //private int defaultCoins = 0;
    //private int defaultScore = 0;
    //public int Score
    //{
    //    get => _score;
    //    set
    //    {
    //        _score = value;
    //        _scoreText.text = _score.ToString();          
    //    }
    //}

    //public int Coin
    //{
    //    get => _coin;
    //    set
    //    {
    //        _coin = value;
    //        _coinText.text = _coin.ToString();
    //    }
    //}

    //public int Lives
    //{
    //    get => _lives;
    //    set
    //    {
    //        _lives = value;
    //        _livesText.text = _lives.ToString();
    //    }
    //}

    //private int _score;
    //private int _coin;
    //private int _lives;

    //[SerializeField] private TextMeshProUGUI _scoreText;
    //[SerializeField] private TextMeshProUGUI _coinText;
    //[SerializeField] private TextMeshProUGUI _livesText;

    //private void Start()
    //{
    //    Coin = defaultCoins;
    //    Lives = defaultLives;
    //    Score = defaultScore;
    //}
}
