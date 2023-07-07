using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Bullet : MonoBehaviour
{

    private float speed = 10.0f;
    public WaitForSeconds timeToStayEnabled = new WaitForSeconds(1.3f);
    public GameManager.PlayerType playerType;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        WhatYouHaveMenu.OnSelectClicked += WhatYouHaveMenuSelectClick;
    }
    private void OnEnable()
    {
        StartCoroutine(EnabledBullet());
    }

    private void OnDestroy()
    {
        WhatYouHaveMenu.OnSelectClicked -= WhatYouHaveMenuSelectClick;
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
           
            if (PhotonNetwork.LocalPlayer != null)
            {


                PhotonNetwork.LocalPlayer.AddScore(collision.gameObject.GetComponent<EnemyBase>().Score);
            }
        }

    }

    private void WhatYouHaveMenuSelectClick()
    {
        spriteRenderer.sprite = WhatYouHaveMenu.Instance.SpriteForBullet;
    }
}
