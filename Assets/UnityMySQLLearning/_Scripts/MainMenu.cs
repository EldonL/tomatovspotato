using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace MySQLLearning
{
    public class MainMenu : MonoBehaviour
    {
        public void GoToRegister()
        {
            SceneManager.LoadScene("RegisterMenu");
        }
    }

}
