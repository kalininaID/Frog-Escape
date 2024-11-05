using UnityEngine;



public class Bullet : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TileMap"))
        {
            Destroy(gameObject); 
        }
    }
}
