using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform target;

    public float range = 20f;

    // Start is called before the first frame update
    void Start()
    {
        // If no target, assign to player using game manager
        if (target == null && GameManager.instance.playerTransform != null)
        {

            target = GameManager.instance.playerTransform;

        }

                // Call distance calculator, find distance between enemy and player
        float distance = GameManager.instance.DistanceCalculator(transform.position, target.position);

        if(distance < range)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {


        
    }
}
