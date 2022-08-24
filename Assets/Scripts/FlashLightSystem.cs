using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] public float lightDecay = .1f;
    [SerializeField] public float angleDecay = 1f;
    [SerializeField] public float minimumAngle = 40f;
    [SerializeField] public float maxAngle = 90f;

    Light myLight;


    private void Start() 
    {
        
        myLight = GetComponent<Light>();
        
    }
    private void FixedUpdate()
    {
        DecreaseLightAngle();
        //DecreaseLightIntensity();
        AngleController();

    }

    private  void AngleController()
    {
        if(myLight.spotAngle> maxAngle)
        {
            myLight.spotAngle = maxAngle;
        }
        
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        if(myLight.spotAngle> maxAngle)
        {
            myLight.spotAngle = maxAngle;
        }
        else
        {
            myLight.spotAngle = myLight.spotAngle + restoreAngle;
        }       
    }

    public void RestoreLightIntensity(float intensityAmount)
    {
        myLight.spotAngle += intensityAmount;
    }



    private void DecreaseLightAngle()  // Decrease Light Angle
    {
        if(myLight.spotAngle <=minimumAngle)
        {
            return;
        }
        else
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }

    }

    //intensity decrease function

   /* private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;

    }*/
}
