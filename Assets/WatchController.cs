using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchController : MonoBehaviour
{
    [SerializeField]
    private CannonManager cannonManager;
    private TMPro.TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cannonManager.gameOver==false)
        {
            text.text = Math.Round(cannonManager.GetScore(), 4).ToString();
        }
    }
}