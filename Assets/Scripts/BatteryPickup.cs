using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
        [SerializeField] float restoreAngle = 40f;
        


  

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreAngle);
            
            Destroy(gameObject);
            
        }
        

    }


  
}
