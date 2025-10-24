using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    //private GameObject[] StandardSpawners;
    public Transform target;

    public bool hasSpawned = false;

    private float spawnerCooldown = 7;

    public float range = 100f;
    public float minRange = 35f;

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
            Debug.Log("A");

            if (distance < range && distance > minRange)
            {
                Debug.Log("B");
                hasSpawned = true;

                var g = Instantiate(enemy, transform.position, Quaternion.identity);
                g.name = "TEST THING";
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

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, Vector3.forward, range);
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.forward, minRange);
    }
#endif
}
