using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed = 5f; 

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        Vector3 vector3 = new Vector3(x, y, 0);
        vector3 = vector3.normalized * (PlayerSpeed *Time.deltaTime);
        transform.position += vector3;
    }
}
    