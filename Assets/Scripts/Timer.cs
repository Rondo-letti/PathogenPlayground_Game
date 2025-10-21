using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            yield return new WaitForSeconds(1f);
            GameManager.instance.countdownValue--;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
}
