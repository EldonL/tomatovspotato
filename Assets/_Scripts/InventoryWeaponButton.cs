using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryWeaponButton : MonoBehaviour
{
    public string Name { get=>_name; private set=>_name = value; }
    public string Description { get=> _description; private set=> _description = value; }
    [SerializeField] private string _name;
    [SerializeField] private string _description;

    public Button _button;
    public Image _image;
    public int _buttonId;
    public Sprite spriteWeapon;
    private void Awake()
    {
       _button.onClick.AddListener(OnInventoryWeaponButtonClick);

    }

    private void OnInventoryWeaponButtonClick()
    {
        WhatYouHaveMenu.Instance.OnInventoryWeapoinButtonClick(_buttonId);
    }
}
