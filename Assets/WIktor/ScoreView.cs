using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    CannonManager cannonManager;
    // Update is called once per frame
    void Update()
    {
        //if (cannonManager != null) GetComponent<TextMeshProUGUI>().text = cannonManager.GetScore();
    }
}
