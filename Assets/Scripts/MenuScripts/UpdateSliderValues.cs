using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSliderValues : MonoBehaviour
{
    [SerializeField] Slider audioSlider;
    [SerializeField] Slider mouseSlider;

    [SerializeField] TextMeshProUGUI audioValue;
    [SerializeField] TextMeshProUGUI mouseValue;

    void Update()
    {
        audioValue.text = audioSlider.value.ToString("0.0");
        mouseValue.text = mouseSlider.value.ToString("0.0");
    }
}
