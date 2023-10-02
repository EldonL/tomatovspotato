using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebTest : MonoBehaviour
{
    int requestAttemptCount = 0;
    private const int MAX_REQUEST_ATTEMPT_COUNT = 1;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        string url = "http://localhost/webtest.php";
        do
        {
            using(var www = UnityWebRequest.Get(url))
            {
                yield return www.SendWebRequest();
                if(www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.DataProcessingError || www.result == UnityWebRequest.Result.ProtocolError)
                {
                    if (++requestAttemptCount < MAX_REQUEST_ATTEMPT_COUNT)
                    {

                        yield return new WaitForSeconds(2.0f);
                    }
                    else
                    {
                        Debug.Log($"www.result: {www.result} error: {www.error} www.url: {www.url}");
                        Debug.Log($"www.downloadHandler.text is: {www.downloadHandler.text}");
                        yield break;
                    }
                }
                else
                {
                    string[] webResults = www.downloadHandler.text.Split('\t');
                    Debug.Log(webResults[0]);
                    int webNumber = int.Parse(webResults[1]);
                    webNumber *= 2;
                    Debug.Log(webNumber);
                }
            }

        } while (requestAttemptCount > 0);
    }

}
