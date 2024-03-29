using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Vector3 rotationOffset;
    [SerializeField] GameObject pointToFollow;
    // dodaj do template działa wraz z odpowiednią konfiguracją; dodaj do template pocisku, aktywny i bez przypisania do gameobject'u (bo i tak jest zmieniany)
    void Update()
    {
        gameObject.transform.LookAt(pointToFollow.transform);
        gameObject.transform.Rotate(rotationOffset);
    }

    //zwraca samego siebie
    public GameObject SetPointToFollow(GameObject ob)
    {
        pointToFollow = ob;
        return gameObject;
    }

}
