using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Debug.Log("Game Over!");
        }
        
    }
}
