using Unity.VisualScripting;
using UnityEngine;

public class MoveByShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ����
    public Transform shootPoint; // �����, ������ �������� ����
    public float bulletSpeed = 20f; // �������� ����
    public float recoilForce = 100f; // ���� ������
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
        if (Input.GetButtonDown("Fire1")) // ��������, ����� ������ ����
        {
            Shoot();

        }
    }

    void Shoot()
    {
        animator.SetBool("isShoot", true);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // ��������, ��� z-���������� ����� 0

        // ��������� ����������� �� ������ �� ������� ����
        Vector2 shootDirection = (mousePosition - shootPoint.position).normalized;

        // ������� ����
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = shootDirection * bulletSpeed; // ������� ���� � ����������� ����


        float recoilMultiplier = 3f;

        Vector2 recoilForce2 = -shootDirection * recoilForce * recoilMultiplier; // ������������ ���� ������
        // ������������� ����� �������� ��� Rigidbody ���������
        rb.velocity = recoilForce2; // ��������� ���� ������
    }


}
