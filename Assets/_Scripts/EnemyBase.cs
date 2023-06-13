using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public int Score { get => score; }
    [SerializeField]private float speed = 3.0f;
    [SerializeField] private int score = 100;
    public WaitForSeconds timeToStayEnabled = new WaitForSeconds(3.0f);
    [SerializeField] private int defaultLife = 1;
    [SerializeField] private int currentLife;

    protected virtual void Awake()
    {
        currentLife = defaultLife;
    }

    protected virtual void OnEnable()
    {
        StartCoroutine(EnabledEnemy());
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            currentLife -= 1;

            if(currentLife <= 0)
            {
                gameObject.SetActive(false);
                currentLife = defaultLife;
            }

            CollideWithPlayer();
        }
    }

    protected abstract void CollideWithPlayer();

    protected abstract IEnumerator EnabledEnemy();
}
