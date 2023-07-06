using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class TestPlayerScore : MonoBehaviour
{
    public const string PlayerScoreProp = "score";
}
public static class TestScoreExtensions
    {
        public static void SetScore(this Photon.Realtime.Player player, int newScore)
        {
            ExitGames.Client.Photon.Hashtable score = new ExitGames.Client.Photon.Hashtable();  // using PUN's implementation of Hashtable
            score[TestPlayerScore.PlayerScoreProp] = newScore;

            player.SetCustomProperties(score);  // this locally sets the score and will sync it in-game asap.
        }

        public static void AddScore(this Photon.Realtime.Player player, int scoreToAddToCurrent)
        {
            int current = player.GetScore();
            current = current + scoreToAddToCurrent;

        ExitGames.Client.Photon.Hashtable score = new ExitGames.Client.Photon.Hashtable();  // using PUN's implementation of Hashtable
        score[TestPlayerScore.PlayerScoreProp] = current;

            player.SetCustomProperties(score);  // this locally sets the score and will sync it in-game asap.
        }

        public static int GetScore(this Photon.Realtime.Player player)
        {
            object score;
            if (player.CustomProperties.TryGetValue(TestPlayerScore.PlayerScoreProp, out score))
            {
                return (int)score;
            }

            return 0;
        }
    }

