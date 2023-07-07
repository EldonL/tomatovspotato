using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerTextInformation : MonoBehaviour
{
    public string Coins { get => coins.text; set => coins.text = value; }
    [SerializeField] private TextMeshProUGUI coins;
    public string Score { get => score.text; set => score.text = value; }
    [SerializeField] private TextMeshProUGUI score;

}
