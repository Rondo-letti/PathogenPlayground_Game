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

        AudioManager.instance.Stop("LevelOneMusic");
        AudioManager.instance.Stop("LevelTwoMusic");
        AudioManager.instance.Stop("LevelThreeMusic");
        AudioManager.instance.Stop("LevelFourMusic");
        AudioManager.instance.Stop("LevelFiveMusic");        
        
        AudioManager.instance.Play("MainMenuMusic");
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

        AudioManager.instance.Stop("MainMenuMusic");
        AudioManager.instance.Stop("LevelTwoMusic");
        AudioManager.instance.Stop("LevelThreeMusic");
        AudioManager.instance.Stop("LevelFourMusic");
        AudioManager.instance.Stop("LevelFiveMusic");

        AudioManager.instance.Play("LevelOneMusic");
    }

    public static void LevelTwo()
    {
        SceneManager.LoadSceneAsync("LevelTwo");

        AudioManager.instance.Stop("MainMenuMusic");
        AudioManager.instance.Stop("LevelOneMusic");
        AudioManager.instance.Stop("LevelThreeMusic");
        AudioManager.instance.Stop("LevelFourMusic");
        AudioManager.instance.Stop("LevelFiveMusic");

        AudioManager.instance.Play("LevelTwoMusic");
        
    }

    public static void LevelThree()
    {
        SceneManager.LoadSceneAsync("LevelThree");

        AudioManager.instance.Stop("MainMenuMusic");
        AudioManager.instance.Stop("LevelOneMusic");
        AudioManager.instance.Stop("LevelTwoMusic");
        AudioManager.instance.Stop("LevelFourMusic");
        AudioManager.instance.Stop("LevelFiveMusic");

        AudioManager.instance.Play("LevelThreeMusic");
    }

    public static void LevelFour()
    {
        SceneManager.LoadSceneAsync("LevelFour");

        AudioManager.instance.Stop("MainMenuMusic");
        AudioManager.instance.Stop("LevelOneMusic");
        AudioManager.instance.Stop("LevelTwoMusic");
        AudioManager.instance.Stop("LevelThreeMusic");
        AudioManager.instance.Stop("LevelFiveMusic");

        AudioManager.instance.Play("LevelFourMusic");
    }

    public static void LevelFive()
    {
        SceneManager.LoadSceneAsync("LevelFive");

        AudioManager.instance.Stop("MainMenuMusic");
        AudioManager.instance.Stop("LevelOneMusic");
        AudioManager.instance.Stop("LevelTwoMusic");
        AudioManager.instance.Stop("LevelThreeMusic");
        AudioManager.instance.Stop("LevelFourMusic");

        AudioManager.instance.Play("LevelFiveMusic");
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
    
    public static void GameOverLevelFive()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void GameWinLevelOne()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public static void GameWinLevelTwo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public static void GameWinLevelThree()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public static void GameWinLevelFour()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public static void GameWinLevelFive()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public static void Levels()
    {
        SceneManager.LoadSceneAsync("Levels");
    }
}
