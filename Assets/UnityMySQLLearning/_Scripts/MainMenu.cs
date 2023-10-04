using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
namespace MySQLLearning
{
    public class MainMenu : MonoBehaviour
    {
        public TextMeshProUGUI playerDisplay;

        private void Start()
        {
            if(DBManager.LoggedIn)
            {
                playerDisplay.text = "Player: " + DBManager.username;
            }
        }

        public void GoToRegister()
        {
            SceneManager.LoadScene("RegisterMenu");
        }

        public void GoToLogin()
        {
            SceneManager.LoadScene("Login");
        }

        public void GoToGame()
        {
            SceneManager.LoadScene("Game");
        }
    }

}
