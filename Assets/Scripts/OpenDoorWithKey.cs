using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorWithKey : MonoBehaviour
{
    public GameObject openDoorPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null && player.hasKey) 
            {
                OpenDoor(); 
            }
        }
    }

    private void OpenDoor()
    {
        Instantiate(openDoorPrefab, transform.position, transform.rotation);
        Destroy(gameObject); 
    }
}
