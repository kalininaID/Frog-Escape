using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorWithKey : MonoBehaviour
{
    public GameObject openDoorPrefab; // Префаб открытой двери

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Проверяем, что столкновение с игроком
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null && player.hasKey) // Проверяем наличие ключа у игрока
            {
                OpenDoor(); // Метод для открытия двери
            }
        }
    }

    private void OpenDoor()
    {
        Instantiate(openDoorPrefab, transform.position, transform.rotation);
        Destroy(gameObject); // Удаляем закрытую дверь
    }
}
