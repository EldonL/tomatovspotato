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
            if (PhotonNetwork.LocalPlayer==collision.gameObject.GetComponent<Player>().PhotonPlayer)
                collision.gameObject.GetComponent<PhotonView>().RPC("CollectCoin", RpcTarget.All, Coins);

            if (view.IsMine)
            {               
                PhotonNetwork.Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
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
