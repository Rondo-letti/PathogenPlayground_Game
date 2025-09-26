using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUpPowerup : MonoBehaviour
{
    private bool timeUp;
    public float spawnCooldown = 10;

    void Start()
    {
        timeUp = false;
    }

    void Update()
    {
        if (timeUp == true)
        {
            spawnCooldown -= Time.deltaTime;

            if (spawnCooldown <= 0)
            {
                timeUp = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                spawnCooldown = 10;

            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && timeUp == false)
        {

            GameManager.instance.countdownValue = GameManager.instance.countdownValue + 10;

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            timeUp = true;

        }

    }
    
}
