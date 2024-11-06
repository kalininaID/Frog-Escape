using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salvation : MonoBehaviour
{
    public GameObject heartPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            MoveByShoot playerMovement = collision.gameObject.GetComponent<MoveByShoot>();
            if (playerMovement != null)
            {
                playerMovement.DisableMovement();
                ShowHeartAnimation();
            }
        }
    }

    private void ShowHeartAnimation()
    {
        GameObject heart = Instantiate(heartPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        StartCoroutine(WaitForHeartAnimation(heart.GetComponent<Animator>()));
    }

    private IEnumerator WaitForHeartAnimation(Animator heartAnimator)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
