using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
public abstract class EnemyBase : MonoBehaviour
{
    public int Score { get => score; }
    [SerializeField]private float speed = 3.0f;
    [SerializeField] private int score = 100;
    public WaitForSeconds timeToStayEnabled = new WaitForSeconds(3.0f);
    [SerializeField] private int defaultLife = 1;
    private int currentLife;
    [SerializeField] private GameObject explosionPrefab;
    protected PhotonView view;
    [SerializeField] TextMeshProUGUI lifePointtext;

    protected virtual void Awake()
    {
        currentLife = defaultLife;
        lifePointtext.text = $"{currentLife}HP";
        view = GetComponent<PhotonView>();
    }

    protected virtual void OnEnable()
    {
        StartCoroutine(EnabledEnemy());
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            currentLife -= 1;
            lifePointtext.text = $"{currentLife}HP";
            if (currentLife <= 0)
            {
                if (view.IsMine)
                {
                    view.RPC("EnemyDestroyed", RpcTarget.All);
                    PhotonNetwork.Destroy(gameObject);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                currentLife = defaultLife;
            }

            CollideWithPlayer();
        }
    }

    [PunRPC]
    protected virtual void EnemyDestroyed()
    {
        GameObject explosion;
        explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
    }


    protected abstract void CollideWithPlayer();

    protected abstract IEnumerator EnabledEnemy();
}
