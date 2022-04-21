using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 Offset;
    [SerializeField]
    private Vector3 OffsetRotation;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position+ Offset;
        transform.localRotation = Quaternion.Euler(target.rotation.eulerAngles+OffsetRotation);
    }
}
