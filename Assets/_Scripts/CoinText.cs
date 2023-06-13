using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinText : MonoBehaviour
{
    public WaitForSeconds timeToStayEnabled = new WaitForSeconds(1.0f);
    private float _speed = 1.0f;
    public string Text { get => text.text; set => text.text = value; }
    [SerializeField] private TextMeshProUGUI text;
    private void OnEnable()
    {
        StartCoroutine(EnabledCoin());
    }

    private void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    private IEnumerator EnabledCoin()
    {
        if (gameObject.activeInHierarchy)
        {
            yield return timeToStayEnabled;
            gameObject.SetActive(false);
        }
        else
            yield break;
    }
}
