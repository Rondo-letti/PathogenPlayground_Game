using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{

    private Transform target;

    public float moveSpeed = 3f;
    public float rotationSpeed = 180f;
    public float range = 15f;
    float despawnDist = 50f;

    public bool canDespawn = true;

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

        if (target == null)
        {
            //Do nothing
            return;
        }

        // Call distance calculator, find distance between enemy and player
        float distance = GameManager.instance.DistanceCalculator(transform.position, target.position);

        // If the enemy is far enough away, destroy itself
        if (distance > despawnDist && canDespawn == true)
        {
            Destroy(gameObject);
            Debug.Log("Enemy is destroyed!");
        }

        if (distance < range)
        {
            // So long as the enemy is within range, move towards it at rate speed.
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
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
    


}
