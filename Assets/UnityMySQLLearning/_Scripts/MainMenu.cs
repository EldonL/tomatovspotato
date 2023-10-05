using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
namespace MySQLLearning
{


    public class MainMenu : MonoBehaviour
    {
        public Button registerButton;
        public Button loginButton;
        public Button playButton;
        public TextMeshProUGUI playerDisplay;

        private void Start()
        {
            if(DBManager.LoggedIn)
            {
                playerDisplay.text = "Player: " + DBManager.username;
            }
            registerButton.interactable = !DBManager.LoggedIn;
            loginButton.interactable = !DBManager.LoggedIn;
            playButton.interactable = DBManager.LoggedIn;

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
