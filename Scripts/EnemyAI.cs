using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3.5f;
    public float stoppingDistance = 6f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (player == null)
            Debug.LogError("EnemyAI: Player transform not assigned!");
        if (rb == null)
            Debug.LogError("EnemyAI: Rigidbody component not found!");
    }

    void Update()
    {
        if (player == null || rb == null) return;

        float dist = Vector3.Distance(transform.position, player.position);

        if (dist > stoppingDistance)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            rb.velocity = new Vector3(dir.x * moveSpeed, rb.velocity.y, dir.z * moveSpeed);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }
}
