using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class PlayerTextInformation : MonoBehaviour
{
    public string NickName { get => nickName.text; set => nickName.text = value; }
    [SerializeField] private TextMeshProUGUI nickName;
    public string Lives { get => lives.text; set => lives.text = value; }
    [SerializeField] private TextMeshProUGUI lives;
    public string Coins { get => coins.text; set => coins.text = value; }
    [SerializeField] private TextMeshProUGUI coins;
    public string Score { get => score.text; set => score.text = value; }
    [SerializeField] private TextMeshProUGUI score;   

}
