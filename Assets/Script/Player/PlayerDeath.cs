using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private bool isDead = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Obstacle") ||
            collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        // ֪ͨ GameManager
        GameManager.Instance.PlayerDied();
    }
}
