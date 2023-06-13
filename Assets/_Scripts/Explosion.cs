using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public WaitForSeconds timeToStayEnabled = new WaitForSeconds(1.0f);
    private void OnEnable()
    {
        StartCoroutine(EnabledObject());
    }

    private IEnumerator EnabledObject()
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
