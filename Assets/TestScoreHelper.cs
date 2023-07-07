using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestCode
{


    public class TestScoreHelper : MonoBehaviour
    {
        public int Score;

        int _currentScore;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (PhotonNetwork.LocalPlayer != null)
                {
                    Debug.Log("etnered");
                    Score += 1;

                    PhotonNetwork.LocalPlayer.SetScore(Score);
                }
            }

        }
    }
}