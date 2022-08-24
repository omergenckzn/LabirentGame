using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    [SerializeField] GameObject gm;

    void Update()
    {
        
        bool condition = gm.GetComponent<GameManager>().condition;

        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        bool condition = gm.GetComponent<GameManager>().condition;

        if (condition)
        {
            if(collision.gameObject.tag == "Finish")
            {
                gm.GetComponent<GameManager>().LoadNextLevel();
            }
            
        }

    }
}
