using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 15f;
    public float fireRate = 1f;
    public float range = 12f;

    private float nextFire;
    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj == null)
        {
            Debug.LogError("EnemyShooting: Player not found! Tag player with 'Player'.");
            enabled = false;
            return;
        }
        player = playerObj.transform;
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= range && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || bulletSpawn == null)
        {
            Debug.LogWarning("EnemyShooting: bulletPrefab or bulletSpawn not assigned!");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
            rb.velocity = bulletSpawn.forward * bulletSpeed;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
            bulletScript.SetOwner(false);

        Destroy(bullet, 3f);
    }
}
