using Unity.VisualScripting;
using UnityEngine;

public class MoveByShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public Transform shootPoint; // Точка, откуда вылетает пуля
    public float bulletSpeed = 20f; // Скорость пули
    public float recoilForce = 100f; // Сила отдачи
    private Rigidbody2D rb;

    public float distance;
    public LayerMask layerMask;
    public int damage;

    [Header("Player Animation Srttings")]
    public Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Например, левая кнопка мыши
        {
            Shoot();

        }
    }

    void Shoot()
    {
        animator.SetBool("isShoot", true);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Убедимся, что z-координата равна 0

        // Вычисляем направление от игрока до позиции мыши
        Vector2 shootDirection = (mousePosition - shootPoint.position).normalized;

        // Создаем пулю
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = shootDirection * bulletSpeed; // Двигаем пулю в направлении мыши


        float recoilMultiplier = 3f;

        Vector2 recoilForce2 = -shootDirection * recoilForce * recoilMultiplier; // Рассчитываем силу отдачи
        // Устанавливаем новую скорость для Rigidbody персонажа
        rb.velocity = recoilForce2; // Применяем силу отдачи
    }


}
