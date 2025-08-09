using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashBehaviour : MonoBehaviour
{

    private Transform target;

    float moveSpeed = 3f;
    float rotationSpeed = 180f;
    float range = 15f;
    float despawnDist = 30f;


    float pauseDistance = 5f;
    float pauseTimer = 0.4f;

    public EnemyDashState state;
    private Vector3 playerLastPos;

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
            case EnemyDashState.IDLE:
                break;
            case EnemyDashState.SLOWFOLLOW:
                OnSlowFollow();
                break;
            case EnemyDashState.DASHCHARGE:
                OnChargeDash();
                break;
        }

        if (target == null)
        {
            //Do nothing
            return;
        }

        // Call distance calculator, find distance between enemy and player
        float distance = GameManager.instance.DistanceCalculator(transform.position, target.position);

        // If the enemy is far enough away, destroy itself
        if (distance > despawnDist)
        {
            Destroy(gameObject);
            //Debug.Log("Enemy is destroyed!");
        }


        // Rotate toward the target (player)
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    // Set the target of the enemy
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void OnSlowFollow()
    {

        float distance = GameManager.instance.DistanceCalculator(transform.position, target.position);

        // Logic for movement
        if (distance < range)
        {
            // So long as the enemy is within range, move towards it at rate speed.
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        
        playerLastPos = target.position;

        // When we are close enough to the player, activate dash pause aka charge
        if (distance <= pauseDistance)
        {
            state = EnemyDashState.DASHCHARGE;
        }
    }

    void OnChargeDash()
    {

        // When within pauseDistance, the timer starts - start pausing
        pauseTimer -= Time.deltaTime;
        moveSpeed = 0f;

        // If the timer reaches zero, dash
        if (pauseTimer <= 0)
        {
            moveSpeed = 9f;
            playerLastPos = target.position;
            state = EnemyDashState.DASH;
        }

        // Record current players position, 


    }


}

public enum EnemyDashState
{
    IDLE, SLOWFOLLOW, DASHCHARGE, DASH
}
