using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TestCode
{


    public class TestScorePanel : MonoBehaviourPunCallbacks
    {
        public GameObject PlayerOverviewEntryPrefab;

        private Dictionary<int, GameObject> playerListEntries;

        public void Awake()
        {
            playerListEntries = new Dictionary<int, GameObject>();

            foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerList)
            {
                GameObject entry = Instantiate(PlayerOverviewEntryPrefab);
                entry.transform.SetParent(gameObject.transform);
                entry.transform.localScale = Vector3.one;
                //entry.GetComponent<TextMeshProUGUI>().color = AsteroidsGame.GetColor(p.GetPlayerNumber());
                entry.GetComponent<TextMeshProUGUI>().text = string.Format("{0}\nScore: {1}\nLives: {2}", p.NickName, p.GetScore(), 3);

                playerListEntries.Add(p.ActorNumber, entry);
            }
        }

        public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
        {
            GameObject entry;
            if (playerListEntries.TryGetValue(targetPlayer.ActorNumber, out entry))
            {
                entry.GetComponent<TextMeshProUGUI>().text = string.Format("{0}\nScore: {1}\nLives: {2}", targetPlayer.NickName, targetPlayer.GetScore(), 3);
            }
        }
    }
}