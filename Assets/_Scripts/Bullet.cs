using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Bullet : MonoBehaviour
{

    private float speed = 10.0f;
    private float timeBeforeDestroy = 2.0f;

    public SpriteRenderer spriteRenderer;
    public Photon.Realtime.Player Owner { get; private set; }
    private void Awake()
    {
        WhatYouHaveMenu.OnSelectClicked += WhatYouHaveMenuSelectClick;
    }

    private void Start()
    {
        Destroy(gameObject, timeBeforeDestroy);
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

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="enemy")
        {
            Destroy(gameObject);

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
