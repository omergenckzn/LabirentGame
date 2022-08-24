using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float moveSpeed = 2.0f;
    Vector3 forward, right;
    Vector3 lookPos;
    AudioSource audioSource;
    [SerializeField] AudioClip walkingSound;
    [SerializeField] AudioClip outOfAmmoSound;
    [SerializeField] AudioClip ammoPickUpSound;
    [SerializeField] AudioClip deathSound;
    bool isWalking = false;
    bool isPlaying = false;
    Animator animator;
    [SerializeField] public int ammo=5;
    bool outAmmo = false;
    int health;
    bool deadbool;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ammo")
        {
            

            ammo += 5;
            audioSource.PlayOneShot(ammoPickUpSound);
            Invoke("DestroyAmmo", 1);

           
        }
        


    }
    void DestroyAmmo()
    {
        FindObjectOfType<AmmoDestroy>().DestroyAmmo();
    }


    void Start()
    {

        rb = GetComponent<Rigidbody>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        audioSource = GetComponent<AudioSource>();
        animator = transform.GetChild(1).GetComponent<Animator>();
        deadbool = false;
    }

    // Update is called once per frame


    void Update()
    {
        MoveHandler();
        ShootCameraHandler();
        WalkShootHandler();
        MouseLook();
        AmmoHandler();
        DeathHandler();

    }

    private void DeathHandler()
    {
        health = transform.GetComponent<PlayerHealth>().playerHitPoint;
        if (health <= 0&&deadbool==false)
        {
            animator.SetBool("death", true);
            audioSource.PlayOneShot(deathSound);
            deadbool = true;
        }
        ;
    }

    private void MoveHandler()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (isPlaying == false)
            {
                walkSound();
            }
            move();

        }
        else
        {
            StopMove();
        }
    }

    private void WalkShootHandler()
    {
        if (isWalking && Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("walkshoot", true);
        }
    }

    private void ShootCameraHandler()
    {
        if (Input.GetButtonDown("Fire1") && !outAmmo)
        {
            FindObjectOfType<CameraShake>().Shake(3, 0.5f);
            animator.SetBool("shoot", true);
        }
        else if (ammo <= 0 && Input.GetButtonDown("Fire1"))
        {
            audioSource.PlayOneShot(outOfAmmoSound);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("shoot", false);
            animator.SetBool("walkshoot", false);
        }
    }

    private void StopMove()
    {
        animator.SetBool("walk", false);
        isWalking = false;
        stopSound();
    }

    private void AmmoHandler()
    {
        if (ammo <= 0)
        {
            outAmmo = true;
            FindObjectOfType<Shooting>().enabled = false;
            FindObjectOfType<CameraShake>().Shake(0, 0);
            

        }
        else
        {
            outAmmo = false;
            FindObjectOfType<Shooting>().enabled = true;
            
        }
    }

    private void walkSound()
    {
        audioSource.clip = walkingSound;
        audioSource.loop = true;
        audioSource.Play();
        
       isPlaying = true;
      
    }
    private void stopSound()
    {
        audioSource.Stop();
        isPlaying = false;
    }



    private void MouseLook()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit raycastHit;

        if(Physics.Raycast(ray,out raycastHit, 100))
        {
            lookPos = raycastHit.point;
        }

        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;
        transform.LookAt(transform.position + lookDir, Vector3.up);

    }

    private void move()
    {
        isWalking = true;
        animator.SetBool("walk", true);

        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

}
