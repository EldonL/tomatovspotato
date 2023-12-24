using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace UnityFirebaseLearning
{
    public class ChangeLevelOnClick : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private string _levelToLoad;

        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(_levelToLoad);
        }


    }

}
