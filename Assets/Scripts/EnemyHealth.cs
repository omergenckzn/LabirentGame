using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health=100.0f;

    private void OnParticleCollision(GameObject collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            healthHandler(30);
            
        }
    }


    public void healthHandler(float damage)
    {
        
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    

    
}
