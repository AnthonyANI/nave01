using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueController : MonoBehaviour
{
    public TextMeshProUGUI sliderValueLabel;
    public string stringFormat = "0";

    // Start is called before the first frame update
    void Start()
    {
        if (sliderValueLabel)
        {
            UpdateSliderValueLabel();
        }
    }

    public void UpdateSliderValueLabel()
    {
        sliderValueLabel.text = Math.Round(gameObject.GetComponent<Slider>().value, 3).ToString(stringFormat);
    }
}
