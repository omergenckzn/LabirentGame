using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ParticleSystemSound : MonoBehaviour
{

    [SerializeField] ParticleSystem pSystem;
    [SerializeField] AudioClip OnBirthSound;
    [SerializeField] AudioClip OnDeathSound;
    AudioSource aSource;

    int _numberOfParticles = 0;

     void Start()
    {
        aSource = GetComponent<AudioSource>();
    }


    void Update()
        {
            if (!OnBirthSound && !OnDeathSound) { return; }
            var count = pSystem.particleCount;
            if (count < _numberOfParticles)
            { //particle has died

            aSource.PlayOneShot(OnBirthSound);
            
            }
            else if (count > _numberOfParticles)
            { //particle has been born
            
        }
            _numberOfParticles = count;
        }
}
