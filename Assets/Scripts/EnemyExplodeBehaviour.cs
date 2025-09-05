using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplodeBehaviour : MonoBehaviour
{

    private Transform target;

    float moveSpeed = 7f;
    float range = 15f;

    public float explosionTargetScale = 5f;
    public float explosionScaleSpeed = 5f;
    float slowDistance = 2f;
    float explosionDistance = 2f;

    private CircleCollider2D explosionCollider;

    public EnemyExplodeState state;


    // Start is called before the first frame update
    void Start()
    {
        // If no target, assign to player using game manager
        if (target == null && GameManager.instance.playerTransform != null)
        {

            target = GameManager.instance.playerTransform;

        }

    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case EnemyExplodeState.IDLE:
                Idle();
                break;
            case EnemyExplodeState.SLOWFOLLOW:
                OnSlowFollow();
                break;
            case EnemyExplodeState.EXPLODECHARGE:
                OnExplodeCharge();
                break;
            case EnemyExplodeState.EXPLODE:
                OnExplode();
                break;

        }

    }

    public void Idle()
    {
        // Nothing happens, start slow following
        state = EnemyExplodeState.SLOWFOLLOW;
    }

    // Set the target of the enemy
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void OnSlowFollow()
    {

        float distance = GameManager.instance.DistanceCalculator(transform.position, target.position);

        // Logic for movement 
        if (distance < range)
        {
            // So long as the enemy is within range, move towards it at rate speed.
            Move();
        }

        // When we are close enough to the player, activate explode charge aka explode slow
        if (distance <= slowDistance)
        {
            state = EnemyExplodeState.EXPLODECHARGE;
        }

    }

    public void OnExplodeCharge()
    {
        // Slow down
        moveSpeed = 1f;
        state = EnemyExplodeState.EXPLODE;

    }

    public void OnExplode()
    {
        float distance = GameManager.instance.DistanceCalculator(transform.position, target.position);

        if (explosionCollider == null && distance <= explosionDistance)
        {
            // Create explosionCollider
            explosionCollider = gameObject.AddComponent<CircleCollider2D>();
            explosionCollider.isTrigger = true;
            explosionCollider.radius = 10f;
        }

        // Destroy self
        Destroy(gameObject, 0.1f);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.playerHealth = GameManager.instance.playerHealth - GameManager.instance.enemyDamage;
            Debug.Log("Player takes damage");

        } 
    }

    private void Move()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    public enum EnemyExplodeState
    {
        IDLE, SLOWFOLLOW, EXPLODECHARGE, EXPLODE
    }
}
