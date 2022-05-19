using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Vector3 rotationOffset;
    [SerializeField] GameObject pointToFollow;
    // dodaj do template dzia�a wraz z odpowiedni� konfiguracj�; dodaj do template pocisku, aktywny i bez przypisania do gameobject'u (bo i tak jest zmieniany)
    void Start()
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
