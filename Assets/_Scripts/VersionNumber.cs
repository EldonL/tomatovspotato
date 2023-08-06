using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class VersionNumber : MonoBehaviour
{
    private TextMeshProUGUI versionNumber;
    // Start is called before the first frame update
    void Awake()
    {
        versionNumber = GetComponent<TextMeshProUGUI>();
        versionNumber.text = Application.version;   
    }


}
