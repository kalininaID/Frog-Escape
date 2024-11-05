using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false; // ��������� �����

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ���������, �������� �� ������ �������
        if (other.CompareTag("Player") && !isOpen)
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ���������, �������� �� ������ �������
        if (other.CompareTag("Player") && isOpen)
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        animator.SetTrigger("Open"); // ��������� �������� ��������
        isOpen = true; // ������������� ��������� ����� ��� ��������
    }

    private void CloseDoor()
    {
        animator.SetTrigger("Close"); // ��������� �������� ��������
        isOpen = false; // ������������� ��������� ����� ��� ��������
    }
}
