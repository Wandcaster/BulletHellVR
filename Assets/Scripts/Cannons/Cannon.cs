using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannon;
    public int id;
    public Cannon(GameObject cannon, int id)
    {
        this.cannon = cannon;
        this.id = id;
    }

}
