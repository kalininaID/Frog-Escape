using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int healthCount;
    public Text healthText;

    void Start()
    {
        
    }

    void Update()
    {
        healthText.text = healthCount.ToString();
    }
}
