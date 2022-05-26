using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    float value;
    public void ChangeSlider(Slider slider)
    {
        slider.value += value;
    }
    public void ChangeValue(float value)
    {
        this.value = value;
    }



}
