using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIBehaviour : MonoBehaviour
{
    public TMP_Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        if (healthText == null)
        {
            healthText = GetComponent<TMP_Text>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + GameManager.instance.playerHealth.ToString();
    }

    /*public ProgressBar CreateProgressBar()
    {
        var progressBar = new ProgressBar
        {
            title = "Infection Progress",
            lowValue = 0f,
            highValue = 100f, 
            value = 0f
        }

        
    }*/
}
