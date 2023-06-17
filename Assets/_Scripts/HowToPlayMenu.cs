using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HowToPlayMenu : MonoBehaviour
{
    [SerializeField] private GameObject _root;
    [SerializeField] private Button _closeButton;

     public delegate void HowToPlayMenuAction();
     public static event HowToPlayMenuAction OnCloseClicked;

    // Start is called before the first frame update
    void Start()
    {
        _root.SetActive(false);
        StartMenu.OnHowToPlayClicked += HowToPlayClick;
        _closeButton.onClick.AddListener(OnCloseClick);
    }

    private void OnDestroy()
    {
        StartMenu.OnHowToPlayClicked -= HowToPlayClick;
        _closeButton.onClick.RemoveAllListeners();
    }

    private void HowToPlayClick()
    {
        _root.SetActive(true);
    }

    private void OnCloseClick()
    {
        OnCloseClicked?.Invoke();
        _root.SetActive(false);
    }
}
