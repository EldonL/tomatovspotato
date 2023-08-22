using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;
public class WhatYouHaveMenu : MonoBehaviour
{
    public static WhatYouHaveMenu Instance;
    [SerializeField] private GameObject _root;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _selectButton;
    [SerializeField] private Button _storeButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private string quitToMainScene = "MainMenuScene";

    [SerializeField] public List<InventoryWeaponButton> inventoryWeaponList = new List<InventoryWeaponButton>();
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;

    private InventoryWeaponButton selectedWeaponButton; 
    public Sprite SpriteForBullet { get => _spriteForBullet; private set => _spriteForBullet = value; }
    private Sprite _spriteForBullet;
    
    public Sprite SpriteForHat { get => _spriteForHat; private set => _spriteForHat = value; }
    private Sprite _spriteForHat;

    public delegate void ClickStoreAction();
    public static event ClickStoreAction OnStoreClicked;
    
    public delegate void ClickCloseAction();
    public static event ClickCloseAction OnCloseClicked;

    public delegate void ClickSelectAction();
    public static event ClickSelectAction OnSelectClicked;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        CanvasUI.OnClicked += PauseButtonPressed;
        _closeButton.onClick.AddListener(OnCloseClick);
        _quitButton.onClick.AddListener(OnQuitClick);
        _storeButton.onClick.AddListener(OnStoreClick);
        _selectButton.onClick.AddListener(OnSelectClick);
        BuyMenu.OnCloseClicked += BuyMenuClose;
        _root.SetActive(false);
        int buttonIdIndex = 0;
        foreach(var inventorybutton in inventoryWeaponList)
        {
            inventorybutton._buttonId = buttonIdIndex;
            buttonIdIndex++;
        }

        _selectButton.interactable = false;
    }

    private void OnDisable()
    {
        _selectButton.interactable = false;
    }

    private void OnDestroy()
    {
        CanvasUI.OnClicked -= PauseButtonPressed;
        _closeButton.onClick.RemoveAllListeners();
        _quitButton.onClick.RemoveAllListeners();
        _storeButton.onClick.RemoveAllListeners();
        _selectButton.onClick.RemoveAllListeners();
        BuyMenu.OnCloseClicked -= BuyMenuClose;
        Instance = null;
    }

    private void PauseButtonPressed()
    {
        _root.SetActive(true);
    }

    private void OnCloseClick()
    {
        Time.timeScale = 1.0f;
        OnCloseClicked?.Invoke();
        _root.SetActive(false);
    }

    private void OnQuitClick()
    {
        Time.timeScale = 1.0f;
        PhotonNetwork.Disconnect();
    }

    private void OnStoreClick()
    {
        _root.SetActive(false);
        OnStoreClicked?.Invoke();
    }

    private void OnSelectClick()
    {
        _spriteForBullet = selectedWeaponButton.spriteWeapon;
        _spriteForHat = selectedWeaponButton._image.sprite;
        _selectButton.interactable = false;
        OnSelectClicked?.Invoke();
        Time.timeScale = 1.0f;
        _root.SetActive(false);
        OnCloseClicked?.Invoke();
    }

    private void BuyMenuClose()
    {
        _root.SetActive(true);
    }

    public  void OnInventoryWeapoinButtonClick(int id)
    {
        _selectButton.interactable = true;
        foreach (var inventorybutton in inventoryWeaponList)
        {
            if(inventorybutton._buttonId==id)
            {
                inventorybutton._button.interactable = false;
                _title.text=inventorybutton.Name;
                _description.text = inventorybutton.Description;
                selectedWeaponButton = inventorybutton;
            }
            else
            {
                inventorybutton._button.interactable = true;

            }

        }
    }

}
