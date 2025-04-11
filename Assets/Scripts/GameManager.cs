using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
  
    public Transform playerTransform;    

    public float playerHealth = 100f;
    public float enemyDamage = 25f;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    // Calculates the distance between two positions
    public float DistanceCalculator(Vector2 enemyPos, Vector2 playerPos)
    {
      
        // Get the distance between the enemy and the player
		float distance = Vector2.Distance(enemyPos, playerPos);    
		return distance;
    }



}
