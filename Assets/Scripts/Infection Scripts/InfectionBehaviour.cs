using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InfectionBehaviour : MonoBehaviour
{
    public bool tileCollided;
    public float maskTargetScale = 10f;
    public float maskScaleSpeed = 5f;

    public GameObject winScreen;
    public GameObject gameCanvas;
    private Transform activeMaskTransform;

    // Create a list to hold each mask
    private List<Transform> growingMasks = new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetScale = new Vector3(maskTargetScale, maskTargetScale, 1f);

        for (int i = growingMasks.Count - 1; i >= 0; i--)
        {
            // Each growingMask in the list undergoes the scaling animation
            Transform maskTransform = growingMasks[i];
            if (maskTransform == null)
            continue;

            maskTransform.localScale = Vector3.Lerp(maskTransform.localScale, targetScale, maskScaleSpeed * Time.deltaTime);
        }
    }     


    // 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Tile"))
        {
            //Debug.Log("Player colliding with tile.");
            SpriteRenderer tileRenderer = other.GetComponent<SpriteRenderer>();
            bool tileCollided = false;

            // Add a object with a sprite mask to the tiles 
            if (other.transform.Find("TileMask") == null)
            {
                GameObject maskObj = new GameObject("TileMask");
                maskObj.transform.SetParent(other.transform);
                maskObj.transform.localPosition = Vector3.zero;

                SpriteMask mask = maskObj.AddComponent<SpriteMask>();
                mask.sprite = GameManager.instance.tileMaskSprite;

                maskObj.transform.localScale = Vector3.zero;
                growingMasks.Add(maskObj.transform);

                tileCollided = true;

                //Debug.Log("Sprite Mask Assigned");
            }

            InfectionTracker(tileRenderer, tileCollided);
       
        }
    }

    // Yellow tiles represent infection area, certain amount of infection = win
    public void InfectionTracker(SpriteRenderer tileRenderer, bool tileCollided)
    {
        // If the tiles turn yellow, add to the infection value
        if(tileCollided == true)
        {
            GameManager.instance.infectionValue += 1;
            //Debug.Log(GameManager.instance.infectionValue);
        }

        // If the infection value is at X, win condition
        if (GameManager.instance.infectionValue == GameManager.instance.infectionWinValue)
        {
            //Debug.Log("You Win!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

            //Time.timeScale = 0;
            //gameCanvas.SetActive(false);
           
            //winScreen.SetActive(true);

        }
    }
}
