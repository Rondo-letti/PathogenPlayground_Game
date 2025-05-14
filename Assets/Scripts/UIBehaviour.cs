using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBehaviour : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        if (healthText == null)
        {
            healthText = GetComponent<TMP_Text>();
        }

        if (timerText == null)
        {
            timerText = GetComponent<TMP_Text>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + GameManager.instance.playerHealth.ToString();
        }
    
        if (timerText != null)
        {
            timerText.text = "Time Left: " + GameManager.instance.countdownValue.ToString();
        }
    }

    public static void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    //public void PauseMenu()
    //{
    //    SceneManager.LoadSceneAsync("PauseMenu");
    //}

    public static void HowToPlay()
    {
        SceneManager.LoadSceneAsync("HowToPlay");
    }

    public static void Quit()
    {
        Application.Quit();
    }

    public static void LevelOne()
    {
        SceneManager.LoadSceneAsync("LevelOne");
    }

    public static void LevelTwo()
    {
        SceneManager.LoadSceneAsync("LevelTwo");
    }

    public static void GameOver()
    {
        SceneManager.LoadSceneAsync("GameOver");
    }

    public static void GameWin()
    {
        SceneManager.LoadSceneAsync("GameWin");
    }
}
