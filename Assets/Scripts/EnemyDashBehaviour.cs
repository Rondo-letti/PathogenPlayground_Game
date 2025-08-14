using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashBehaviour : MonoBehaviour
{

    private Transform target;

    float moveSpeed = 3f;
    float rotationSpeed = 180f;
    float range = 15f;
    float detectingRange = 10f;
    float despawnDist = 30f;


    float pauseDistance = 5f;
    public float pauseTimer = 2;

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

        //state = EnemyDashState.IDLE;

    }

    // Update is called once per frame
    void Update()
    {


        switch (state)
        {
            case EnemyDashState.IDLE:
                Idle();
                break;
            case EnemyDashState.SLOWFOLLOW:
                OnSlowFollow();
                break;
            case EnemyDashState.DASHCHARGE:
                OnChargeDash();
                break;
            case EnemyDashState.DASH:
                Dash();
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

    public void Idle()
    {
        // Nothing happens
        Debug.Log("Enemy is idle");
        state = EnemyDashState.SLOWFOLLOW;
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
            playerLastPos = target.position;
            Move();
            Debug.Log("Enemy is following");
        }

        playerLastPos = target.position;

        // When we are close enough to the player, activate dash pause aka charge
        if (distance <= pauseDistance)
        {
            pauseTimer = 2;
            state = EnemyDashState.DASHCHARGE;
        }
    }

    void OnChargeDash()
    {

        // When within pauseDistance, the timer starts - start pausing
        pauseTimer -= Time.deltaTime;
        moveSpeed = 0f;
        Debug.Log("Enemy is charging");


        // If the timer reaches zero, dash
        if (pauseTimer <= 0)
        {
            playerLastPos = target.position;
            state = EnemyDashState.DASH;
        }

    }

    void Dash()
    {
        float distance = GameManager.instance.DistanceCalculator(transform.position, target.position);

        // pass move speed and move to position
        DashMovement(10);



        // Head toward playerLastPos and overshoot
        if (distance > detectingRange)
        {
            pauseTimer = 2;
            state = EnemyDashState.SLOWFOLLOW;
        }

    }

    private void Move()
    {
        Vector3 direction = (playerLastPos - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
    
    private void DashMovement(float dashSpeed)
    {
        Debug.Log("enemy is dashing");
        Vector3 direction = (playerLastPos - transform.position).normalized;
        transform.position += direction * dashSpeed * Time.deltaTime;
    }


}

public enum EnemyDashState
{
    IDLE, SLOWFOLLOW, DASHCHARGE, DASH
}
