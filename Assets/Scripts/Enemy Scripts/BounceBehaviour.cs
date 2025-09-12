using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBehaviour : MonoBehaviour
{
    Rigidbody2D player;
    Rigidbody2D enemy;
    Vector2 playerPosition;
    Vector2 enemyPosition;
    Vector2 bounceTrajectory; 
    float bounceForce = 200f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerPosition = player.transform.position;
        Debug.Log("Player and Player Position get.");
        
    }

    // On collision, enemy bounces off player
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Debug.Log("Colliding with Enemy.");
            enemy = col.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log("Enemy Rigidbody get.");
            enemyPosition = enemy.transform.position;
            Debug.Log("Enemy position get.");

            bounceTrajectory = playerPosition - enemyPosition;
            Debug.Log("Bounce trajectory get.");

            enemy.AddForce(bounceTrajectory*bounceForce);
            Debug.Log(bounceTrajectory);
        }
        
    }

    void OnCollisionExit2D(Collision2D col)
    {
        
    }
}
