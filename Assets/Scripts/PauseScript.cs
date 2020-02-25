using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool isPaused;
   public GameObject[] pauseObjects;
    public GameObject UI;
   

    // Start is called before the first frame update
    
    void Awake()
    {
        
    }
    void Start()
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
       
    }
    void Update()
    {
       
    }
    public void pauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            
            
            showPaused();
            

        }
        else
        {
            
            Time.timeScale = 0;
            isPaused = true;
           
            hidePaused();
            
        }
    }
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
}
