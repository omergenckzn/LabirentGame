using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticleCol : MonoBehaviour
{
    [SerializeField] ParticleSystem blood;
    private void OnParticleCollision(GameObject other) {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("hit");
            Instantiate(blood, other.transform.position, Quaternion.identity);
        }
        

    }
}
