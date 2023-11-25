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

                //TODO: Score would probably be increased here 
                score += 50;
                scoreText.text = score.ToString();
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

                //TODO: Red snow score would probably be increased here 
               redScore += 15;
               redScoreText.text = redScore.ToString();
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

                //TODO: Yellow snow score would probably be increased here 
               yellowScore += 5;
               yellowScoreText.text = yellowScore.ToString();

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
