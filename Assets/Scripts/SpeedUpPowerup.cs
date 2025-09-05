using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPowerup : MonoBehaviour
{

    public float speedUpgradeDuration = 3;
    bool isSpeeding = false;

    void Update()
    {
        if (isSpeeding == true)
        {
            speedUpgradeDuration -= Time.deltaTime;

            if (speedUpgradeDuration <= 0)
            {
                GameManager.instance.playerMoveSpeed = GameManager.instance.playerMoveSpeed - 2f;
                speedUpgradeDuration = 3;
                isSpeeding = false;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameManager.instance.playerMoveSpeed = GameManager.instance.playerMoveSpeed + 2f;
            isSpeeding = true;
        }

    }


}
