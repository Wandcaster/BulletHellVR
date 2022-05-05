using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIConfig : MonoBehaviour
{
    [SerializeField] public int cannonAmount;
    [SerializeField] public float radius;
    [SerializeField] public int queueLimit;
    [SerializeField] public float minDelay;
    [SerializeField] public float maxDelay;
    [SerializeField] public int hp;

    private void Start()
    {
        //update text on slider's to match current value
        //Component parent = gameObject.GetComponentInChildren(typeof(TMPro.TMP_Text));

        var tmp = new List<string>();
        tmp.Add(cannonAmount.ToString());
        tmp.Add(radius.ToString());
        tmp.Add(queueLimit.ToString());
        tmp.Add(minDelay.ToString());
        tmp.Add(maxDelay.ToString());
        tmp.Add(hp.ToString());
        tmp.Add("Start".ToString());

        int i = 0;
        foreach (Transform child in this.transform)
        {
            if (child.GetComponent<TMPro.TMP_Text>())
            {
                child.GetComponent<TMPro.TMP_Text>().text += tmp[i++];
            }

        }



    }

    public ConfigData GetData()
    {
        cannonAmount = (int)gameObject.transform.Find("Cannon Amount").Find("Slider").GetComponent<Slider>().value;
        radius = (int)gameObject.transform.Find("Radius").Find("Slider").GetComponent<Slider>().value;
        queueLimit = (int)gameObject.transform.Find("Queue Limit").Find("Slider").GetComponent<Slider>().value;
        minDelay = (int)gameObject.transform.Find("Min Delay").Find("Slider").GetComponent<Slider>().value;
        maxDelay = (int)gameObject.transform.Find("Max Delay").Find("Slider").GetComponent<Slider>().value;
        hp = (int)gameObject.transform.Find("HP").Find("Slider").GetComponent<Slider>().value;

        Debug.Log(cannonAmount + "|" + radius + "|" + queueLimit + "|" + minDelay + "|" + maxDelay + "|" + hp);
        return new ConfigData(cannonAmount, radius, queueLimit, minDelay, maxDelay, hp);
    }


}
