using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionBehaviour : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Tile"))
        {
            Debug.Log("Player colliding with tile.");
            SpriteRenderer tileRenderer = other.GetComponent<SpriteRenderer>();

            //add a Sprite Mask to each collided tile 
            if (other.transform.Find("TileMask") == null)
            {
                GameObject maskObj = new GameObject("TileMask");
                maskObj.transform.SetParent(other.transform);
                maskObj.transform.localPosition = Vector3.zero;

                SpriteMask mask = maskObj.AddComponent<SpriteMask>();
                mask.sprite = GameManager.instance.tileMaskSprite;

                //Debug.Log("Sprite Mask Assigned");
            }

            InfectionTracker(tileRenderer);
       
        }
    }

    //yellow tiles represent infection area, certain amount of infection = win
    public void InfectionTracker(SpriteRenderer tileRenderer)
    {
        //if the tiles turn yellow, add to the infection value
        if(tileRenderer.color == new Color(1f, 1f, 0f, 0.2f))
        {
            GameManager.instance.infectionValue += 1;
            Debug.Log(GameManager.instance.infectionValue);
        }

        //if the infection value is at X, win condition
        if (GameManager.instance.infectionValue == 3000)
        {
            Debug.Log("You Win!");
        }
    }
}
