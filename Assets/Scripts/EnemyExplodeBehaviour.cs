using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplodeBehaviour : MonoBehaviour
{

    private Transform target;

    float moveSpeed = 3f;
    float rotationSpeed = 180f;
    float range = 15f;
    float detectingRange = 10f;
    float despawnDist = 30f;

    float slowDistance = 2f;

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
            playerLastPos = target.position;
            Move();
        }

        playerLastPos = target.position;

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
        // Create explosionCollider
        if (gameObject.AddComponent<Collider2D>() == null)
        {
            var Collider = gameObject.AddComponent<CircleCollider2D>();
            Collider.isTrigger = true;
            circleCollider2D.range = 0f;
        }

        // Scale explosionCollider from enemy position out to maxExplosionRange over 1 second  
        circleCollider2D.range = 10f;
        // Destroy self

    }

    public enum EnemyExplodeState
    {
        IDLE, SLOWFOLLOW, EXPLODECHARGE, EXPLODE
    }
}
