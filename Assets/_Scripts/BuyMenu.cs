using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyMenu : MonoBehaviour
{
    [SerializeField] private GameObject _root;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _buyButton;


    public delegate void ClickCloseBuyAction();
    public static event ClickCloseBuyAction OnCloseClicked;
    private void Awake()
    {
        _root.SetActive(false);
        WhatYouHaveMenu.OnStoreClicked += WhatYouHaveMenuStoreClicked;
        _closeButton.onClick.AddListener(OnCloseClick);
        _buyButton.onClick.AddListener(OnBuyClick);
    }
    private void OnDestroy()
    {
        WhatYouHaveMenu.OnStoreClicked -= WhatYouHaveMenuStoreClicked;
        _closeButton.onClick.RemoveAllListeners();
        _buyButton.onClick.RemoveAllListeners();
    }

    private void WhatYouHaveMenuStoreClicked()
    {
        _root.SetActive(true);
    }

    private void OnCloseClick()
    {
        OnCloseClicked?.Invoke();
        _root.SetActive(false);
    }

    private void OnBuyClick()
    {

    }
}
