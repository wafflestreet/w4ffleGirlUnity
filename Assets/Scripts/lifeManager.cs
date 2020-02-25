using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class lifeManager : MonoBehaviour
{
    //public int startingLives;
    public int lifeCounter;



    public Text theText;
    public GameObject GameOverScreen;
    public GameObject button;

    public string mainMenu;
    public float waitAfterGameOver;
    public float gameOver;
    public GameObject waffle;
    public GameObject movingGameOver;

    public GameObject controls;
    public GameObject livesUI;

    



    // Start is called before the first frame update
    void Start()
    {

        
        theText = GetComponent<Text>();
        lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");
       
       

    }

    // Update is called once per frame
    void Update()
    {


        theText.text = "x " + lifeCounter;
        {
            if (lifeCounter <= 0)

                GameOverScreen.SetActive(true);
            




            // ScoreManager.Instance.CheckForNewHighScore();


        }
        if (GameOverScreen.activeSelf)
        {

            controls.SetActive(false);
            livesUI.SetActive(false);

        }
        //if(waitAfterGameOver < 0)
        //{ SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); }



    }
    public void GiveLife()
    {
        lifeCounter++;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);

    }
    public void TakeLife()
    {
        lifeCounter--;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }

    public void AddScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}

