using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpPowerup : MonoBehaviour
{
void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            GameManager.instance.playerHealth = GameManager.instance.playerHealth + 30f;
            Debug.Log(GameManager.instance.playerHealth);

            if (GameManager.instance.playerHealth >= 120f)
            {
                GameManager.instance.playerHealth = 90f;
            }

        }


    }
}
