using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    public Transform target;

    float moveSpeed = 3f;
    float range = 10f;
    float despawnDist = 30f;

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

    // Call distance calculator, find distance between enemy and player
    float distance = GameManager.instance.DistanceCalculator(transform.position, target.position);

    // If the enemy is far enough away, destroy itself
    if (distance > despawnDist)
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

    }

    // Set the target of the enemy
	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}

}
