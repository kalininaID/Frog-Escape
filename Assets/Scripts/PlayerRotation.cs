using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    Vector3 pos;
    Camera main;
    [Header("Player Animation Srttings")]
    public Animator animator;

    void Start()
    {
        main = FindFirstObjectByType<Camera>();
    }

    void Update()
    {
        Flip();
        pos = main.WorldToScreenPoint(transform.position);
    }

    void Flip()
    {
        if (Input.mousePosition.x < pos.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.mousePosition.x > pos.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void OnShootAnimationEnd()
    {
        animator.SetBool("isShoot", false);
    }
}
