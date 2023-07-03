using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LobbyCreateButton : MonoBehaviour
{
    public string ButtonText { get => buttonText.text; set => buttonText.text = value; }

    [SerializeField] private TextMeshProUGUI buttonText;

    public bool PressButton { get => connectButton.interactable; set => connectButton.interactable = value; }
    [SerializeField] private UnityEngine.UI.Button connectButton;

    private void OnEnable()
    {
        ButtonText = "Create";
        PressButton = true;
    }
}
