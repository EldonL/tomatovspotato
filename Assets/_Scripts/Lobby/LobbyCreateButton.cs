using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LobbyCreateButton : MonoBehaviour
{
    public string ButtonText { get => buttonText.text; set => buttonText.text = value; }
    [SerializeField] private TextMeshProUGUI buttonText;

    private void OnEnable()
    {
        ButtonText = "Create";
    }
}
