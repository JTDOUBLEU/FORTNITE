using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate = 3f;
    [SerializeField] private float spawnRadius = 2f;
    [SerializeField] private int maxEnemies = 10;

    private float nextSpawnTime;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
        if (player == null)
            Debug.LogError("EnemySpawner: Player not found!");
        if (enemyPrefab == null)
            Debug.LogError("EnemySpawner: Enemy prefab not assigned!");
    }

    void Update()
    {
        if (player == null || enemyPrefab == null)
            return;

        // Count current enemies in scene
        int enemyCount = FindObjectsOfType<EnemyHealth>().Length;

        if (Time.time > nextSpawnTime && enemyCount < maxEnemies)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos;

        // Spawn near player or at spawn points
        if (spawnPoints.Length > 0)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            spawnPos = spawnPoint.position + Random.insideUnitSphere * spawnRadius;
        }
        else
        {
            // Spawn around player if no spawn points set
            spawnPos = player.position + Random.onUnitSphere * 15f;
        }

        // Keep spawn at ground level
        spawnPos.y = 1f;

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        
        // Link enemy to player
        EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
        if (enemyAI != null)
            enemyAI.player = player;
    }
}
