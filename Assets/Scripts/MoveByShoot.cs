using Unity.VisualScripting;
using UnityEngine;


public class MoveByShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    private Rigidbody2D rb;

    public float bulletSpeed = 20f;
    public float recoilForce = 100f;
    public LayerMask layerMask;

    [Header("Player Animation Srttings")]
    public Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        animator.SetBool("isShoot", true);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // ¬ычисл€ем направление от игрока до позиции мыши
        Vector2 shootDirection = (mousePosition - shootPoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = shootDirection * bulletSpeed; // ƒвигаем пулю в направлении мыши


        float recoilMultiplier = 2f;

        Vector2 recoilForce2 = -shootDirection * recoilForce * recoilMultiplier;
        rb.velocity = recoilForce2;
    }

    public void DisableMovement()
    {
        rb.velocity = Vector2.zero; 
    }

}
