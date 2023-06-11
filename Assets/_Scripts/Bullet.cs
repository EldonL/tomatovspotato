using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float speed = 10.0f;
    public WaitForSeconds timeToStayEnabled = new WaitForSeconds(1.3f);
    public GameManager.PlayerType playerType;
    private void OnEnable()
    {
        StartCoroutine(EnabledBullet());
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private IEnumerator EnabledBullet()
    {
        if (gameObject.activeInHierarchy)
        {
            yield return timeToStayEnabled;
            gameObject.SetActive(false);
        }
        else
            yield break;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="enemy")
        {
            gameObject.SetActive(false);
            ScoreManager.Instance.AddScore(playerType, collision.gameObject.GetComponent<Enemy>().Score);
        }

    }
}
