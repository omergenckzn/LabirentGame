using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEnemyHealth : MonoBehaviour
{
    [SerializeField] AudioClip takeDamage;
    [SerializeField] AudioClip deathSound;
    [SerializeField] int currentHealth = 2;
    AudioSource aSource;





    private void Update()
    {
        aSource = GetComponent<AudioSource>();
    }

    void LateUpdate()
    {
        if (currentHealth <= 0)
        {
            Invoke("DestroyEnemy", 1.5f);
        }

    }

    private void OnParticleCollision(GameObject other)
    {
        if (currentHealth > 0)
        {
            aSource.PlayOneShot(takeDamage);
        }
        else if (currentHealth <= 0)
        {
            aSource.PlayOneShot(deathSound);
        }


        currentHealth--;

    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }


}

