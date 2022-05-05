using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateSelf : MonoBehaviour
{
    [SerializeField] string text;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    private void ValueChangeCheck()
    {
        gameObject.transform.parent.GetComponent<TMPro.TMP_Text>().text = text + slider.value;
    }
}
