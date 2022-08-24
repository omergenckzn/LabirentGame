using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject keys;       // Keys parent object
    public int collectedKey = 0;            // Collected key Counter
    public int goalKey = 3;       // Target Key amount
    public bool condition;                 //Win condition flag

    void Start()
    {
        goalKey = keys.transform.childCount;    // define Target key to existing key amount in the level
        condition = false;
        
        
    }


    void Update()
    {
        if(goalKey == collectedKey)
        {
            condition = true;
        }


    }


    public void LoadNextLevel() // Load Next level Method
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);


    }

    

}
