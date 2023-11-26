using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace PlayerPrefLearning
{
    public class PlayerPrefTesting : MonoBehaviour
    {
        public TextMeshProUGUI settext;

        [System.Serializable]
        public class SavePlayerDataJson
        {
            public string playerName;
            public int playerHealth;
            public int playerScore;
        }
        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                PlayerPrefs.SetInt("EldonTestInt", 24);
                settext.text = "SetInt Triggered";
            }
            if(Input.GetKeyDown(KeyCode.G))
            {
                int testInt = PlayerPrefs.GetInt("EldonTestInt");
                Debug.Log(testInt);
                settext.text =  "GetInt Triggered: value is: "+testInt.ToString();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                PlayerPrefs.DeleteKey("EldonTestInt");
                settext.text = "DeleteKey triggered";
                PlayerPrefs.DeleteKey("SavedPlayer");
            }

            if(Input.GetKeyDown(KeyCode.J))
            {
                SavePlayerDataJson savedPlayer = new SavePlayerDataJson()
                {
                    playerName = "The man of the hour",
                    playerHealth = 6,
                    playerScore = 3000
                };
                PlayerPrefs.SetString("SavedPlayer", JsonUtility.ToJson(savedPlayer));
                PlayerPrefs.Save();
            }
            if(Input.GetKeyDown(KeyCode.L))
            {
                var playerData = JsonUtility.FromJson<SavePlayerDataJson>(PlayerPrefs.GetString("SavedPlayer"));
                settext.text = $"Name:{playerData.playerName} \n Health:{playerData.playerHealth} \n {playerData.playerScore}";
            }
        }
    }
}

