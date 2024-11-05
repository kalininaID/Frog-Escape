using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false; // Состояние двери

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, является ли объект игроком
        if (other.CompareTag("Player") && !isOpen)
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Проверяем, является ли объект игроком
        if (other.CompareTag("Player") && isOpen)
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        animator.SetTrigger("Open"); // Запускаем анимацию открытия
        isOpen = true; // Устанавливаем состояние двери как открытое
    }

    private void CloseDoor()
    {
        animator.SetTrigger("Close"); // Запускаем анимацию закрытия
        isOpen = false; // Устанавливаем состояние двери как закрытое
    }
}
