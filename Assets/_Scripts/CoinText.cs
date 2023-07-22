using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinText : MonoBehaviour
{

    private float _speed = 1.0f;
    public string Text { get => text.text; set => text.text = value; }
    [SerializeField] private TextMeshProUGUI text;
    private float timeBeforeDestroy = 1.0f;

    private void Start()
    {
        Destroy(gameObject, timeBeforeDestroy);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }


}
