using UnityEngine;
using UnityEngine.UI;

public class InfectionSlider : MonoBehaviour
{
    public Slider slider;

    // Set Slider values
    void Start()
    {
        slider.minValue = 0;
        slider.maxValue = 300;
        slider.value = GameManager.instance.infectionValue;
    }

    // Set Infection Value from Game Manager
    void Update()
    {
        if (slider != null)
        {
            slider.value = GameManager.instance.infectionValue;
        }
    }
}
