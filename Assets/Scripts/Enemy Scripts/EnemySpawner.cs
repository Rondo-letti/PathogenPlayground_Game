using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform target;

    public bool hasSpawned = false;

    private float spawnerCooldown = 7;
    


    public float range = 35f;
    public float minRange = 25f;

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

        if (enemy != null && hasSpawned == false)
        {
            // Call distance calculator, find distance between enemy and player
            float distance = GameManager.instance.DistanceCalculator(transform.position, target.position);


            if (distance < range && distance > minRange)
            {
                hasSpawned = true;

                Instantiate(enemy, transform.position, Quaternion.identity);
            }
        }

        if (hasSpawned == true)
        {
            spawnerCooldown -= Time.deltaTime;

            if (spawnerCooldown <= 0)
            {
                hasSpawned = false;
                spawnerCooldown = 7;
            }

        }
        
        

    }
}
