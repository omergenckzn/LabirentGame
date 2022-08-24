using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int playerHitPoint;
    [SerializeField] int numOfHearts;

    [SerializeField] Image[] hearts;

    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;

    private void Start()
    {
        
        playerHitPoint = 3;
        
    }


    private void OnParticleCollision(GameObject other)
    {
        playerHitPoint--;
        Debug.Log("Damaged");
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Enemy")
        {
            HealthHandler();
        }

    }

    void Update()
    {

        if(playerHitPoint > numOfHearts)
        {
            playerHitPoint = numOfHearts;
        }


        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < playerHitPoint)
            {
                hearts[i].sprite = fullHeart;
            }else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }

        Debug.Log(playerHitPoint);
        if(playerHitPoint <= 0)
        {

            Invoke("restartLevel", 3.0f);
        }

    }


    void HealthHandler()
    {
        playerHitPoint--;

    }

    public void restartLevel()
    {
        int sceneCount = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneCount);
    }

}
