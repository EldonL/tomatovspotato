using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
public abstract class EnemyBase : MonoBehaviour
{

    [SerializeField]private float speed = 3.0f;
    [SerializeField] private int score = 100;
    public WaitForSeconds timeToStayEnabled = new WaitForSeconds(3.0f);
    [SerializeField] private int defaultLife = 1;
    private int currentLife;
    [SerializeField] private GameObject explosionPrefab;
    protected PhotonView view;
    [SerializeField] TextMeshProUGUI lifePointtext;
    [SerializeField] Slider lifePointSlider;
    WaitForSeconds enemyHitAffectWaitTime = new WaitForSeconds(3.0f);

    public int Score 
    {
        get 
        {
            if(currentLife<=1)
            {
                return score;
            }
            else
            {
                return 0;
            }
        }
       
    }

    protected virtual void Awake()
    {
        currentLife = defaultLife;
        lifePointtext.text = $"{currentLife}HP";
        lifePointSlider.value = (float)currentLife / (float)defaultLife;
        view = GetComponent<PhotonView>();
        lifePointtext.gameObject.SetActive(false);
        lifePointSlider.gameObject.SetActive(false);
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

            if (currentLife <= 0)
            {
                if (view.IsMine)
                {
                    EnemyDestroyed();
                    PhotonNetwork.Destroy(gameObject);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                currentLife = defaultLife;
            }
            else
            {
                lifePointtext.text = $"{currentLife}HP";
                lifePointSlider.value = (float)currentLife / (float)defaultLife;
                StartCoroutine(EnemyHitRoutine());
            }
            CollideWithPlayer();


        }
    }

    protected virtual void EnemyDestroyed()
    {
        view.RPC("EnemyDestroyedRPC", RpcTarget.All);
    }

    [PunRPC]
    protected virtual void EnemyDestroyedRPC()
    {
        GameObject explosion;
        explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
    }


    protected abstract void CollideWithPlayer();

    protected abstract IEnumerator EnabledEnemy();

    protected virtual IEnumerator EnemyHitRoutine()
    {
        if (lifePointSlider.gameObject.activeInHierarchy)
            yield break;
        lifePointtext.gameObject.SetActive(true);
        lifePointSlider.gameObject.SetActive(true);

        yield return enemyHitAffectWaitTime;
        lifePointtext.gameObject.SetActive(false);
        lifePointSlider.gameObject.SetActive(false);
        yield break;
    }
}
