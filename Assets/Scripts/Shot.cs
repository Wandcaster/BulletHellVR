using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] float power;
    [SerializeField]
    AudioClip hitAudio;


    public delegate void Hit();
    public event Hit hit;

    public void Shoot(Transform target)
    {
//        Debug.Log(target);
        GetComponent<Rigidbody>().AddForce(
            power*(target.position - transform.position)
            );
        GetComponent<FollowPlayer>().SetPointToFollow(target.gameObject);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            PlayerHit();
        }
            
    }

    private void PlayerHit()
    {
        if(hit!=null)hit();
        GetComponent<AudioSource>().clip = hitAudio;
        GetComponent<AudioSource>().Play();
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Renderer>().enabled = false;
        Destroy(gameObject,GetComponent<AudioSource>().clip.length);
    }
}
