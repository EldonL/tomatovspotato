using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Camera _camera;
    private float _timer = 0.0f;
    private float _timerToReloadBullet = 0.2f;
    public void Start()
    {
        _camera = Camera.main;
    }
    public void Shoot()
    {
        GameObject bullet = PlayerBulletPoolInstance.Instance.GetPooledObject();
        if(bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
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
}
