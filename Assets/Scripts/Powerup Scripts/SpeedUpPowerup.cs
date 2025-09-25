using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPowerup : MonoBehaviour
{

    public float speedUpgradeDuration = 2;
    bool isSpeeding = false;

    SpriteRenderer playerSpriteRenderer;
    Color playerColor;

    void Start()
    {

        if (playerSpriteRenderer == null)
        {
            playerSpriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        if (isSpeeding == true)
        {
            speedUpgradeDuration -= Time.deltaTime;
            playerColor = new Color(0, 255, 206);
            playerSpriteRenderer.color = playerColor;

            if (speedUpgradeDuration <= 0)
            {
                GameManager.instance.playerMoveSpeed = 8f;
                speedUpgradeDuration = 2;
                isSpeeding = false;
                playerSpriteRenderer.color = Color.white;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameManager.instance.playerMoveSpeed = 12f;
            isSpeeding = true;
            //Destroy(gameObject);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

    }


}
