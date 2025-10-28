using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField] private ParticleSystem PlayerDamageParticle = default;

    private bool playerDead = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // If the player collides with the enemy, take damage 
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //Debug.Log("Colliding with enemy");

            GameManager.instance.playerHealth = GameManager.instance.playerHealth - GameManager.instance.enemyDamage;


            //Debug.Log(GameManager.instance.playerHealth);

            // If player takes damage, play particle effect
            PlayerDamageParticle.Play();

        }


        if (GameManager.instance.playerHealth <= 0)
        {
            playerDead = true;
        }


    }

    void Update()
    {
        if (GameManager.instance.playerHealth <= 0 || playerDead == true)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            //GameManager.instance.gameOver = true;
            //Debug.Log("Dead");
        }
    }


}
