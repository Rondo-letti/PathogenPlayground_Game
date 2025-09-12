using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashBehaviour : MonoBehaviour
{

    private Transform target;

    float moveSpeed = 3f;
    float dashSpeed = 10;
    float rotationSpeed = 180f;
    float range = 15f;
    float detectingRange = 5f;
    float despawnDist = 30f;


    float pauseDistance = 5f;
    public float pauseTimer = 1;

    public EnemyDashState state;
    //private Vector3 playerLastPos;
    private Vector3 desiredMovementDirection;

    bool isDashing;


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
        isDashing = false;

        UpdateDesiredDirection();

        // Logic for movement 
        if (distance <= range)
        {
            // So long as the enemy is within range, move towards it at rate speed.
            Move(moveSpeed);
            //Debug.Log("Enemy is following");
        }

        // When we are close enough to the player, activate dash pause aka charge
        if (distance <= pauseDistance)
        {
            pauseTimer = 1;
            state = EnemyDashState.DASHCHARGE;
        }

    }

    void OnChargeDash()
    {

        // When within pauseDistance, the timer starts - start pausing
        pauseTimer -= Time.deltaTime;
        moveSpeed = 3f;
        //Debug.Log("Enemy is charging");


        // If the timer reaches zero, dash
        if (pauseTimer <= 0)
        {
            UpdateDesiredDirection();
            isDashing = true;
            // instead of position, use direction, method move direction
            state = EnemyDashState.DASH;
        }

    }

    void Dash()
    {
        float distance = GameManager.instance.DistanceCalculator(transform.position, target.position);

        // pass move speed and move to position
        Move(dashSpeed);



        // Head toward playerLastPos and overshoot
        if (distance > detectingRange && isDashing == true)
        {
            pauseTimer = 1;
            state = EnemyDashState.SLOWFOLLOW;
        }

    }

    private void Move(float desiredMoveSpeed)
    {
        
        transform.position += desiredMovementDirection * desiredMoveSpeed * Time.deltaTime;
    }

    private void UpdateDesiredDirection()
    {
        desiredMovementDirection = (target.position - transform.position).normalized;

    }

}

public enum EnemyDashState
{
    IDLE, SLOWFOLLOW, DASHCHARGE, DASH
}
