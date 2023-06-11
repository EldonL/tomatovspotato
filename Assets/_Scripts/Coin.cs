using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Coins { get => coins; }
    [SerializeField] private int coins = 5;
    public WaitForSeconds timeToStayEnabled = new WaitForSeconds(3.0f);
    private float speed = 5.0f;
    private void OnEnable()
    {
        StartCoroutine(EnabledCoin());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            //spawn coin number
            gameObject.SetActive(false);
        }
    }

    private IEnumerator EnabledCoin()
    {
        if (gameObject.activeInHierarchy)
        {
            yield return timeToStayEnabled;
            gameObject.SetActive(false);
        }
        else
            yield break;
    }
}
