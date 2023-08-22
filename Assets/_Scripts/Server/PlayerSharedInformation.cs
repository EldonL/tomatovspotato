using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerSharedInformation : MonoBehaviour
{
    public const string PlayerPotatoEnemyDestroyed = "potatoEnemyDestroyed";

}

public static class PlayerSharedInformationExtensions
{
    public static void SetPotatoEnemyDestroyed(int enemyDestroyed)
    {
        PhotonNetwork.CurrentRoom.SetCustomProperties(new ExitGames.Client.Photon.Hashtable() { { PlayerSharedInformation.PlayerPotatoEnemyDestroyed, enemyDestroyed } });
    }
    
    public static int GetPotatoEnemyDestroyed()
    {
        object enemyDestroyed;
        if(PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(PlayerSharedInformation.PlayerPotatoEnemyDestroyed, out enemyDestroyed))
        {
            return (int)enemyDestroyed;
        }
        return 0;
    }

    public static void AddPotatoEnemyDestroyed(int enemyDestroyed)
    {
        int current = GetPotatoEnemyDestroyed();
        current += enemyDestroyed;
        SetPotatoEnemyDestroyed(current);
    }
}