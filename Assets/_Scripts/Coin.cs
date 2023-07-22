using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Coins { get => coins; }
    [SerializeField] private int coins = 5;
    public WaitForSeconds timeToStayEnabled = new WaitForSeconds(3.0f);
    private float speed = 5.0f;
    protected PhotonView view;
    [SerializeField] private GameObject coinText;
    private void Awake()
    {
        view = GetComponent<PhotonView>();
    }
    private void OnEnable()
    {
        StartCoroutine(EnabledObject());
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
           
            if (view.IsMine)
            {
                view.RPC("CoinCollected", RpcTarget.All);
                PhotonNetwork.Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    [PunRPC]
    private void CoinCollected()
    {
        coinText.GetComponent<CoinText>().Text = coins.ToString();

        GameObject coinTextGameObject;
        coinTextGameObject = Instantiate(coinText, transform.position, transform.rotation) as GameObject;
        coinTextGameObject.transform.parent = CoinPoolInstance.Instance.CoinTextSpawnAboveOtherUI;
    }

    private IEnumerator EnabledObject()
    {
        if (!view.IsMine)
            yield break;
        else
        {
            yield return timeToStayEnabled;
            PhotonNetwork.Destroy(gameObject);

        }
        yield break;
    }
}
