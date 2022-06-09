using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    float value;
    public List<GameObject> cannons;
    public void ChangeSlider(Slider slider)
    {
        slider.value += value;
    }
    public void ChangeValue(float value)
    {
        this.value = value;
    }
    public void SelectCannon(GameObject cannon)
    {
        foreach (var item in cannons)
        {
            if (item != cannon) item.GetComponent<Image>().color = Color.white;
            cannon.GetComponent<Image>().color = Color.green;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            cannons[0].GetComponent<Button>().onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            cannons[1].GetComponent<Button>().onClick.Invoke();
        }
    }
    
}
