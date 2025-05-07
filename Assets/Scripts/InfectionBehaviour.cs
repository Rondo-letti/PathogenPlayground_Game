using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionBehaviour : MonoBehaviour
{

    // If the player is in a certain tile, change colour of tile to yellow
    // If tile is yellow, add value to progress meter

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Tile"))
        {
            //Debug.Log("Player colliding with tile.");
            SpriteRenderer tileRenderer = other.GetComponent<SpriteRenderer>();
            tileRenderer.color = new Color(1f, 1f, 0f, 0.2f);     

            InfectionTracker(tileRenderer);
       
        }
    }

    public void InfectionTracker(SpriteRenderer tileRenderer)
    {
        if(tileRenderer.color == new Color(1f, 1f, 0f, 0.2f))
        {
            GameManager.instance.infectionValue += 1;
            Debug.Log(GameManager.instance.infectionValue);
        }

        if (GameManager.instance.infectionValue == 3000)
        {
            Debug.Log("You Win!");
        }
    }
}
