using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
           // GameManager Script for update collected Key
    AudioSource audioSource;
    [SerializeField] AudioClip keySound;
    public MeshRenderer render;
    public SphereCollider collider;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        render = GetComponent<MeshRenderer>();
        collider = GetComponent<SphereCollider>();
        render.enabled = true;
    }

    private void OnCollisionEnter(Collision other) {



        if(other.gameObject.tag == "Player")        // if Player Collect the Key
        {

            FindObjectOfType<GameManager>().collectedKey++;
            render.enabled = false;      // add 1 to the key counter
            audioSource.PlayOneShot(keySound);
            render.enabled = collider.enabled = false;
            Invoke("destroyObject", 2f);// destroy the gameobject
            

        }
    }

    private void destroyObject()
    {
        Destroy(gameObject);
    }

}
