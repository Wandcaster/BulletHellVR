using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ActiveGravity : MonoBehaviour
{
    private void Start()
    {
        //dOKOÑCZYÆ
        if(Input.GetKeyDown(KeyCode.Space))
        Player.instance.hands[0].AttachObject(gameObject, GrabTypes.Grip);

    }

    [SerializeField]
    float ForceMultiplier;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.gameObject.GetComponent<Rigidbody>().velocity * ForceMultiplier);
            collision.gameObject.GetComponent<FollowPlayer>().enabled = false;
        }
    }
}
