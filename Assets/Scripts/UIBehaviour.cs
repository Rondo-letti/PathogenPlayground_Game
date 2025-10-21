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

    public GameObject lifeOne;
    public GameObject lifeTwo;
    public GameObject lifeThree;

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
        if (GameManager.instance.playerHealth <= 60)
        {
            lifeThree.SetActive(false);
        }

        else
        {
            lifeThree.SetActive(true);
        }

        if (GameManager.instance.playerHealth <= 30)
        {
            lifeTwo.SetActive(false);
        }

        else
        {
            lifeTwo.SetActive(true);
        }

        if (GameManager.instance.playerHealth <= 0)
        {
            lifeOne.SetActive(false);
        }

        else
        {
            lifeOne.SetActive(true);
        }

        if (timerText != null)
        {
            timerText.text = "Time Left: " + GameManager.instance.countdownValue.ToString();
        }

        else
        {
            //Nothing happens
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

    public static void LevelThree()
    {
        SceneManager.LoadSceneAsync("LevelThree");
    }

    public static void LevelFour()
    {
        SceneManager.LoadSceneAsync("LevelFour");
    }

    public static void GameOverLevelOne()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void GameOverLevelTwo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void GameOverLevelThree()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public static void GameOverLevelFour()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void GameWin()
    {
        SceneManager.LoadSceneAsync("GameWin");
    }

    public static void Levels()
    {
        SceneManager.LoadSceneAsync("Levels");
    }
}
