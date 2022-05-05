using Bhaptics.Tact.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHaptic : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<HapticSource>().Play();
    }
}
