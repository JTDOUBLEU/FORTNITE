using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20;
    private bool isPlayerBullet = true;

    public void SetOwner(bool ownerIsPlayer)
    {
        isPlayerBullet = ownerIsPlayer;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Player bullets only hit enemies
        if (isPlayerBullet)
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                Destroy(gameObject);
                return;
            }
        }
        // Enemy bullets only hit player
        else
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Destroy(gameObject);
                return;
            }
        }

        // Destroy on any other collision
        if (!collision.gameObject.CompareTag("Bullet"))
            Destroy(gameObject);
    }
}
