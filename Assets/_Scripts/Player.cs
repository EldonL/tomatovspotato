using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class Player : MonoBehaviour
{

    private Camera _camera;
    private float _timer = 0.0f;
    private float _timerToReloadBullet = 0.2f;
    [SerializeField] private GameManager.PlayerType playerType;
    [SerializeField] private GameObject _root;

    [SerializeField] public Sprite[] bodySprites;
    [SerializeField] public SpriteRenderer body;
    [SerializeField] private SpriteRenderer arm;
    [SerializeField] private SpriteRenderer hat;
    private BoxCollider2D playerBoxCollider2D;

    private Vector3 originalPosition;

    PhotonView view;
    Photon.Realtime.Player player;
    public GameObject BulletPrefab;
    private void Awake()
    {
        originalPosition = gameObject.transform.position;
        CanvasUI.OnClicked += CanvasUIPause;
        WhatYouHaveMenu.OnCloseClicked += WhatYouHaveMenuClose;
        WhatYouHaveMenu.OnSelectClicked += WhatYouHaveMenuSelectClick;
        view = GetComponent<PhotonView>();
        playerBoxCollider2D = GetComponent<BoxCollider2D>();

    }

    public void Start()
    {
        _camera = Camera.main;
    }

    public void Update()
    {
        if (view.IsMine)
        {
            PlayerMovement();
            _timer += Time.deltaTime;
            if (_timer > _timerToReloadBullet)
            {
                view.RPC("Shoot", RpcTarget.AllViaServer, transform.position, transform.rotation);
                _timer = 0.0f;
            }

        }
    }

    private void OnDestroy()
    {
        CanvasUI.OnClicked -= CanvasUIPause;
        WhatYouHaveMenu.OnCloseClicked -= WhatYouHaveMenuClose;
        WhatYouHaveMenu.OnSelectClicked -= WhatYouHaveMenuSelectClick;
    }

    public void SetPlayerInfo(Photon.Realtime.Player _player)
    {
        player = _player;
        UpdatePlayerItem(player);
    }

    private void UpdatePlayerItem(Photon.Realtime.Player player)
    {
        if (view.IsMine)
        {
            view.RPC("ChangeAvatar", RpcTarget.AllBuffered, player);
        }

    }

    [PunRPC]
    void ChangeAvatar(Photon.Realtime.Player player)
    {
        if (player.CustomProperties.ContainsKey("playerAvatar"))
        {
            body.sprite = bodySprites[(int)player.CustomProperties["playerAvatar"]];
        }
        else
        {
            body.sprite = bodySprites[0];
        }
    }



    [PunRPC]
    public void Shoot(Vector3 position, Quaternion rotation, PhotonMessageInfo info)
    {
         float lag = (float) (PhotonNetwork.Time - info.SentServerTime);
            GameObject bullet;

            /** Use this if you want to fire one bullet at a time **/
            bullet = Instantiate(BulletPrefab, position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Bullet>().InitializeBullet(view.Owner);
    }



    private void PlayerMovement()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 moveToMouse = new Vector3(_camera.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, moveToMouse, 10.0f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PhotonNetwork.LocalPlayer != null && view.IsMine)
        {
            if (collision.gameObject.tag == "CoinA" || collision.gameObject.tag == "CoinB" || collision.gameObject.tag == "CoinC")
                PhotonNetwork.LocalPlayer.AddCoin(collision.gameObject.GetComponent<Coin>().Coins);
                    
        }

        if (collision.gameObject.tag == "enemy")
        {
            //ScoreManager.Instance.MinusLives(playerType, 1);

            if (view.IsMine)
            {
                view.RPC("HitByEnemy", RpcTarget.All, player);
            }
        }
    }



    [PunRPC]
    void HitByEnemy(Photon.Realtime.Player player)
    {
        StartCoroutine(HitByEnemyRoutine(player));
    }

    IEnumerator HitByEnemyRoutine(Photon.Realtime.Player player)
    {
        object lives;
        if (player.CustomProperties.TryGetValue(TomatoGame.PLAYER_LIVES, out lives))
        {
            player.SetCustomProperties(new ExitGames.Client.Photon.Hashtable { { TomatoGame.PLAYER_LIVES, ((int)lives <= 1) ? 0 : ((int)lives - 1) } });
        }
        //GameObject explosion = ExplosionPoolInstance.Instance.GetPooledObjectA();
        //explosion.transform.position = transform.position;
        //explosion.transform.position = transform.position;
        //explosion.SetActive(true);
        _root.SetActive(false);
        playerBoxCollider2D.enabled = false;
        yield return new WaitForSeconds(0.75f);
        gameObject.transform.position = originalPosition;
        yield return new WaitForSeconds(0.75f);
        _root.SetActive(true);
        playerBoxCollider2D.enabled = true;
        yield break;
    }


    private void CanvasUIPause()
    {
        _root.SetActive(false);
    }

    private void WhatYouHaveMenuClose()
    {
        _root.SetActive(true);
    }

    private void WhatYouHaveMenuSelectClick()
    {
        arm.sprite = WhatYouHaveMenu.Instance.SpriteForBullet;
        hat.sprite = WhatYouHaveMenu.Instance.SpriteForHat;
    }
}
