using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            StartCoroutine(OpenDoorAndLoadScene());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isOpen)
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        animator.SetTrigger("Open");
        isOpen = true;
    }

    private void CloseDoor()
    {
        animator.SetTrigger("Close");
        isOpen = false;
    }

    private IEnumerator OpenDoorAndLoadScene()
    {
        OpenDoor();
        yield return new WaitForSeconds(1.5f);

        GoToNextLVL goToNextLVL = gameObject.AddComponent<GoToNextLVL>();
        goToNextLVL.UnlockLevel();
    }


    

}
