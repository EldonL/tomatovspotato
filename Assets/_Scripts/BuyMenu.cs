using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMenu : MonoBehaviour
{
    [SerializeField] private GameObject _root;

    private void Awake()
    {
        _root.SetActive(false);
    }
}
