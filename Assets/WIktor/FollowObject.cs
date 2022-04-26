using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 Offset;
    [SerializeField]
    bool LeftHand;
    [SerializeField]
    bool RightHand;

    private void Start()
    {
        if (LeftHand) StartCoroutine(GetLeftHand());
        if (RightHand) StartCoroutine(GetRightHand());
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + Offset;
        //transform.localRotation = Quaternion.Euler(target.rotation.eulerAngles+OffsetRotation);
    }
    IEnumerator GetLeftHand()
    {
        Transform hand = null;
        while (hand == null)
        {
            yield return new WaitForSeconds(1f);
            if (Player.instance.hands[0].HasSkeleton())
            {
                hand = target.Find("LeftRenderModel Slim(Clone)").Find("vr_glove_left_model_slim(Clone)").Find("slim_l").Find("Root").Find("wrist_r");
            }
            }
            target = hand;
    }
    IEnumerator GetRightHand()
    {
        Transform hand = null;
        while (hand == null)
        {
            yield return new WaitForSeconds(1f);
            if (Player.instance.hands[1].HasSkeleton())
            {
                hand = target.Find("RightRenderModel Slim(Clone)").Find("vr_glove_right_model_slim(Clone)").Find("slim_r").Find("Root").Find("wrist_r");
            }
        }
        target = hand;
    }
}

