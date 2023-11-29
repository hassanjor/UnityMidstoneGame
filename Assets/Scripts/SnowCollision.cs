using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowCollision : MonoBehaviour
{
    //reference to the spawner of the snow
    public GameObject snow;
    SnowSpawner snowSpawner;

    //all score variables
    // Static so it saves in between scenes 
    public static int score = 0;
    public static int redScore = 0;
    public static int yellowScore = 0;

    //All score types texts 
    public Text scoreText;
    public Text redScoreText;
    public Text yellowScoreText;

    void Start()
    {
        //getting access to use variables from the spawner script
        snowSpawner = snow.GetComponent<SnowSpawner>();
     
    }

    //while the player is colliding with snow 
    void OnTriggerStay2D(Collider2D col)
    {
        //check if the tag is snow
        if (col.gameObject.CompareTag("Snow"))
        {
            //check if left mouse button is pressed 
            if (Input.GetKey(KeyCode.Mouse0))
            {
                //Destroy the snow 
                Destroy(col.gameObject);
                //increase the limit of max spawned so more can be spawned
                snowSpawner.maxSpawnLimit++;

                //Score for regular shovel 
                if (BuyItems.regShovelActive == true)
                {
                    score += 150;
                    scoreText.text = score.ToString();
                }

                //Score for gold shovel 
                if(BuyItems.goldShovelActive == true)
                {
                    score += 225;
                    scoreText.text = score.ToString();
                }

                //score for no shovel 
                else if (BuyItems.regShovelActive == false && BuyItems.goldShovelActive == false)
                {
                    score += 50;
                    scoreText.text = score.ToString();
                }


            }

            
        }

        //check if the tag is red snow 
        if(col.gameObject.CompareTag("RedSnow"))
        {
            //check if left mouse button is pressed 
            if (Input.GetKey(KeyCode.Mouse0))
            {
                //Destroy the snow 
                Destroy(col.gameObject);
                //increase the limit of max spawned so more can be spawned
                snowSpawner.maxRedSpawnLimit++;

                //Score for regular shovel 
                if (BuyItems.regShovelActive == true)
                {
                    redScore += 50;
                    redScoreText.text = redScore.ToString();

                }
                //Score for gold shovel 
                if (BuyItems.goldShovelActive == true)
                {
                    redScore += 100;
                    redScoreText.text = redScore.ToString();
                }
                //Score for no shovel 
                else if (BuyItems.regShovelActive == false && BuyItems.goldShovelActive == false)
                {
                    redScore += 15;
                    redScoreText.text = redScore.ToString();
                }
            }
        }

        //check if the tag is yellow snow 
        if(col.gameObject.CompareTag("YellowSnow"))
        {
            //check if left mouse button is pressed 
            if (Input.GetKey(KeyCode.Mouse0))
            {
                //Destroy the snow 
                Destroy(col.gameObject);
                //increase the limit of max spawned so more can be spawned
                snowSpawner.maxYellowSpawnLimit++;

                //Score for regular shovel 
                if (BuyItems.regShovelActive == true)
                {
                    yellowScore += 10;
                    yellowScoreText.text = yellowScore.ToString();
                }

                //Score for gold shovel 
                if (BuyItems.goldShovelActive == true)
                {
                    yellowScore += 20;
                    yellowScoreText.text = yellowScore.ToString();
                }

                //Score for no shovel 
                else if (BuyItems.regShovelActive == false && BuyItems.goldShovelActive == false)
                {
                    yellowScore += 5;
                    yellowScoreText.text = yellowScore.ToString();
                }
            }
        }

    }


    void Update()
    {
        //this is so when we switch scenes the text also stays the same 
        scoreText.text = score.ToString();
        redScoreText.text = redScore.ToString();
        yellowScoreText.text = yellowScore.ToString();
    }



}
