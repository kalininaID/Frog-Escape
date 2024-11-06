using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemsManager : MonoBehaviour
{
    public int gemCount;
    public Text gemsText;

    void Start()
    {
        
    }

    void Update()
    {
        gemsText.text = gemCount.ToString();
    }
}
