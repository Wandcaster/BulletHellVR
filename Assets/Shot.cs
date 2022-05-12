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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) PlayerHit();
    }

    private void PlayerHit()
    {
        hit();
        GetComponent<AudioSource>().clip = hitAudio;
        GetComponent<AudioSource>().Play();
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<Renderer>().enabled = false;
        Destroy(gameObject,GetComponent<AudioSource>().clip.length);
    }
}
