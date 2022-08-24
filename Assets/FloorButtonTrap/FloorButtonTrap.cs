using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButtonTrap : MonoBehaviour
{
    [SerializeField] ParticleSystem partSys;
    [SerializeField] AudioClip stoneSound;
    AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            aSource.PlayOneShot(stoneSound);
            GetComponent<Animator>().SetBool("GoDown", true);
            var emissionModule = partSys.emission;
            emissionModule.enabled = true;
            Invoke("StopEmission", 3);
        }

    }
    void StopEmission()
    {
        var emissionModule = partSys.emission;
        emissionModule.enabled = false;
        GetComponent<Animator>().SetBool("GoDown", false);
    }
}
