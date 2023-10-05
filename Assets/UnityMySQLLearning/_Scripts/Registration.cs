using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace MySQLLearning
{
    public class Registration : MonoBehaviour
    {
        public TMP_InputField nameField;
        public TMP_InputField passwordField;

        public Button submitButton;
        int requestAttemptCount = 0;
        private const int MAX_REQUEST_ATTEMPT_COUNT = 1;

        private void Awake()
        {
            submitButton.interactable = false;
        }
        public void CallRegister()
        {
            StartCoroutine(RegisterRoutine());
        }

        IEnumerator RegisterRoutine()
        {
            string url = "http://localhost/register.php";
            WWWForm form = new WWWForm();
            form.AddField("name", nameField.text);
            form.AddField("password", passwordField.text);
            do
            {
                using (var www = UnityWebRequest.Post(url,form))
                {


                    yield return www.SendWebRequest();


                    if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.DataProcessingError || www.result == UnityWebRequest.Result.ProtocolError)
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
                            Debug.Log("user created successfully");
                            SceneManager.LoadScene("Login");
                        }

                        yield break;
                    }


                }

            } while (requestAttemptCount > 0);
        }

        public void VerifyInputs()
        {
            submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
        }


    }
}



