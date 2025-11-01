using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplodeBehaviour : MonoBehaviour
{

    [SerializeField] private ParticleSystem ExplosionEnemyArea = default;

    private Transform target;

    float range = 15f;

    float slowDistance = 3f;

    public float explodeCountdown = 3;

    private CircleCollider2D explosionCollider;

    public EnemyExplodeState state;

    bool countdownStart = false;



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

        if (countdownStart == true)
        {
            explodeCountdown -= Time.deltaTime;
            Debug.Log(explodeCountdown);
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
            Move(4f);
        }

        // When we are close enough to the player, activate explode charge aka explode slow
        if (distance <= slowDistance)
        {
            state = EnemyExplodeState.EXPLODECHARGE;
        }

    }

    public void OnExplodeCharge()
    {
        Debug.Log("Charging");

        // Slow down
        Move(2f);
        countdownStart = true;

        if (explodeCountdown <= 0)
        {

            state = EnemyExplodeState.EXPLODE;
        }


    }

    public void OnExplode()
    {
        var enemyExplosionEffect = Instantiate(ExplosionEnemyArea, transform.position, Quaternion.identity);
        enemyExplosionEffect.Play();

        if (explosionCollider == null)
        {
            // Create explosionCollider
            explosionCollider = gameObject.AddComponent<CircleCollider2D>();
            explosionCollider.isTrigger = true;
            explosionCollider.radius = 15f;

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

    private void Move(float desiredMoveSpeed)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * desiredMoveSpeed * Time.deltaTime;
    }    


    public enum EnemyExplodeState
    {
        IDLE, SLOWFOLLOW, EXPLODECHARGE, EXPLODE
    }
}
