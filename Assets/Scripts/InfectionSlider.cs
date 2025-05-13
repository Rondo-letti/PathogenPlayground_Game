using UnityEngine;
using UnityEngine.UI;

public class InfectionSlider : MonoBehaviour
{
    public Slider slider;

    void Start()
    {

        slider.minValue = 0;
        slider.maxValue = 3000;
        slider.value = GameManager.instance.infectionValue;
    }

    void Update()
    {
        if (slider != null)
        {
            slider.value = GameManager.instance.infectionValue;
        }
    }
}
