using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

namespace MySQLLearning
{
    public class Game : MonoBehaviour
    {
        public TextMeshProUGUI playerDisplay;
        public TextMeshProUGUI scoreDisplay;
        int requestAttemptCount = 0;
        private const int MAX_REQUEST_ATTEMPT_COUNT = 1;

        private void Awake()
        {
            if (DBManager.username == null)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            }
            playerDisplay.text = "Player: " + DBManager.username;
            scoreDisplay.text = "Score: " + DBManager.score;
        }

        public void CallSaveData()
        {
            StartCoroutine(SavePlayerDataRoutine());
        }

        private IEnumerator SavePlayerDataRoutine()
        {
            WWWForm form = new WWWForm();
            form.AddField("name", DBManager.username);
            form.AddField("score", DBManager.score);

            string url = "http://localhost/savedata.php";
            do
            {
                using (var www = UnityWebRequest.Post(url, form))
                {
                    yield return www.SendWebRequest();


                    if ( www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.DataProcessingError || www.result == UnityWebRequest.Result.ProtocolError)
                    {
                        if (++requestAttemptCount < MAX_REQUEST_ATTEMPT_COUNT)
                        {

                            yield return new WaitForSeconds(2.0f);
                        }
                        else
                        {
                            Debug.Log($"www.result: {www.result} error: {www.error} www.url: {www.url}");
                            Debug.Log($"www.downloadHandler.text: {www.downloadHandler.text}");
                            yield break;
                        }
                    }
                    else
                    {
                        if(www.downloadHandler.text != "0")
                        {
                            Debug.Log($"<color=red> user login failed with error number:{www.downloadHandler.text}</color>");
                        }
                        else
                        {
                            Debug.Log("Game Saved");
                            DBManager.LogOut();
                            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");

                        }

                        yield break;
                    }


                }

            } while (requestAttemptCount > 0);

        }

        public void IncreaseScore()
        {
            DBManager.score++;
            scoreDisplay.text = "Score: " + DBManager.score;
        }
    }


}
