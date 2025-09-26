using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpPowerup : MonoBehaviour
{

    private bool healthUp;
    public float spawnCooldown = 10;

    void Update()
    {
        if (healthUp == true)
        {
            spawnCooldown -= Time.deltaTime;

            if (spawnCooldown <= 0)
            {
                healthUp = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                spawnCooldown = 10;

            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            GameManager.instance.playerHealth = GameManager.instance.playerHealth + 30f;
            //Debug.Log(GameManager.instance.playerHealth);

            if (GameManager.instance.playerHealth >= 120f)
            {
                GameManager.instance.playerHealth = 90f;
            }

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            healthUp = true;


        }


    }
}
