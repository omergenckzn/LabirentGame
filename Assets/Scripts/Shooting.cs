using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    Vector3 lookPos;
    [SerializeField] private Transform BulletPf;
    [SerializeField] float damage = 50.0f;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float speed = 10.0f;
    AudioSource audioSource;
    [SerializeField] AudioClip shootSound;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem bullet;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot();
            ShootSoundHandler();
            AmmoHandler();
            Shootpar();

        }

    }


    private void Shootpar()
    {
        bullet.Play();


    }

    private void AmmoHandler()
    {
        FindObjectOfType<PlayerController>().ammo--;
    }

    private void ShootSoundHandler()
    {
        audioSource.PlayOneShot(shootSound);
    }

    /*private void Shoot()
    {
        muzzleFlash.Play();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, 100))
        {
            lookPos = raycastHit.point;
        }

        Vector3 lookDir = lookPos - transform.position;

        Instantiate(BulletPf, transform.position, Quaternion.LookRotation(-lookDir));
        

        RaycastHit hit;
       
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 200))
        {

            



        }
    }*/


}