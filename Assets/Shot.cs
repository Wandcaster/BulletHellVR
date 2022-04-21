using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] float power;

    public void Shoot(Transform target)
    {
//        Debug.Log(target);
        GetComponent<Rigidbody>().AddForce(
            power*(target.position - transform.position)
            );
    }
}
