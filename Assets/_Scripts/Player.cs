using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Camera _camera;
    private float _timer = 0.0f;
    private float _timerToReloadBullet = 0.2f;
    [SerializeField] private GameManager.PlayerType playerType;

    public void Start()
    {
        _camera = Camera.main;
    }
    public void Shoot()
    {
        Bullet bullet = PlayerBulletPoolInstance.Instance.GetPooledObject();
        if(bullet != null)
        {
            bullet.playerType = playerType;
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.gameObject.SetActive(true);
        }
    }

    public void Update()
    {
        PlayerMovement();
        _timer += Time.deltaTime;
        if(_timer > _timerToReloadBullet)
        {
            Shoot();
            _timer = 0.0f;
        }

    }

    private void PlayerMovement()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 moveToMouse = new Vector3(_camera.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, moveToMouse, 5.0f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="CoinA")
        {
            ScoreManager.Instance.AddCoin(playerType, collision.gameObject.GetComponent<Coin>().Coins);
        }
        if(collision.gameObject.tag == "CoinB")
        {
            ScoreManager.Instance.AddCoin(playerType, collision.gameObject.GetComponent<Coin>().Coins);
        }
        if(collision.gameObject.tag =="CoinC")
        {
            ScoreManager.Instance.AddCoin(playerType, collision.gameObject.GetComponent<Coin>().Coins);
        }
        if (collision.gameObject.tag == "enemy")
        {
            ScoreManager.Instance.MinusLives(playerType, 1);
        }
    }
}
