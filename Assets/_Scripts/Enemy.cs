using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Score { get => score; }
    private float speed = 3.0f;
    [SerializeField] private int score = 100;
    public WaitForSeconds timeToStayEnabled = new WaitForSeconds(3.0f);
    private void OnEnable()
    {
        StartCoroutine(EnabledEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="PlayerBullet")
        {
            //spawn particle
            gameObject.SetActive(false);
        }
    }

    private IEnumerator EnabledEnemy()
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
