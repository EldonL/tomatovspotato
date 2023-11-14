using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace PlayerPrefLearning
{
    public class PlayerPrefTesting : MonoBehaviour
    {
        public TextMeshProUGUI settext;
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
            }
        }
    }
}

