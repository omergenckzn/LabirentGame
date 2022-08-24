using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] TextMeshProUGUI keyCounter;
    [SerializeField] Light playerLight;
    [SerializeField] float mentalChange = 1f;
    [SerializeField] Image currentMentalGlobe;
    [SerializeField] TextMeshProUGUI bulletCountsText;
    [SerializeField] GameObject playerGameObject;
    Animator anim;
    

    float maxMental = 100;
    float currMental = 100f;
    int bulletCount;

    
    FlashLightSystem flash;
    void Start()
    {
        flash = playerLight.GetComponent<FlashLightSystem>();
        anim = currentMentalGlobe.GetComponent<Animator>();
        bulletCount = playerGameObject.GetComponent<PlayerController>().ammo;
       
        
    }

    
    void Update()
    {
        bulletCount = playerGameObject.GetComponent<PlayerController>().ammo;
        bulletCountsText.text = "Ammo: " + bulletCount ;
        keyCounter.text = "Gained Key = " + gm.collectedKey;

        currMental = (playerLight.spotAngle - flash.minimumAngle) * 2;
        MentalController();

        if(currMental <= 0 )
        {
            playerGameObject.GetComponent<PlayerHealth>().playerHitPoint--;

        }

    }


    private void MentalController()
    {
        UpdateMentalGlobe();

        if (MentalControl())
        {
            DecreaseMental();
        }
        GlobeColor();
    }



    private bool MentalControl()
    {

       if(playerLight.spotAngle <= flash.minimumAngle)
       return true;
       else{
        return false;
       }
    }

    public void DecreaseMental()
	{
        Debug.Log("mental dowwwn");
		currMental -= mentalChange * Time.deltaTime;
        GlobeColor();
		if (currMental < 1)
        {
            currMental = 0;
        }		
	}

    private void GlobeColor()
    {
        if(currMental<50f)
        {
        currentMentalGlobe.color = Color.white;
        anim.SetBool("lowMental", true);
        }
        else{
        currentMentalGlobe.color = Color.cyan;
        anim.SetBool("lowMental", false);            
        }
    }

    private void UpdateMentalGlobe()
	{
		float ratio = currMental / maxMental;
		currentMentalGlobe.rectTransform.localPosition = new Vector3(0, currentMentalGlobe.rectTransform.rect.height * ratio - currentMentalGlobe.rectTransform.rect.height, 0);
		//manaText.text = currMental.ToString("0") + "/" + maxMental.ToString("0");
	}




}
