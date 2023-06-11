using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Coins { get => coins; }
    [SerializeField] private int coins = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            //spawn coin number
            Destroy(gameObject);
        }
    }
}
