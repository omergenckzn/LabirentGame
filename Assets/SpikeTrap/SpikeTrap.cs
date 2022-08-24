using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{

    Animator animationController;
    BoxCollider bCollider;
    AudioSource aSource;
    [SerializeField] AudioClip spikeFleshSound;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        animationController = GetComponent<Animator>();
        bCollider = GetComponent<BoxCollider>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");

        if (collision.gameObject.tag == "Player")
        {
            bCollider.enabled = false;
            aSource.PlayOneShot(spikeFleshSound);
            animationController.SetBool("GoUp", true);
            Invoke("GoDown", 3);
        }

    }

    void GoDown()
    {
        animationController.SetBool("GoUp", false);
        bCollider.enabled = true;
        
    }


}
