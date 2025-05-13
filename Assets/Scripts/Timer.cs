using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    public IEnumerator StartCountdown()
    {
        while (GameManager.instance.countdownValue > 0)
        {
            Debug.Log("Countdown: " + GameManager.instance.countdownValue);
            yield return new WaitForSeconds(1.0f);
            GameManager.instance.countdownValue--;
        }

        Debug.Log("Game Over!");
    }
    
}
