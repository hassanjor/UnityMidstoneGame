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

    //all potion counter texts
    public Text bluecounter;
    public Text redCounter;


    void Start()
    {
        //getting access to use variables from the spawner script
        snowSpawner = snow.GetComponent<SnowSpawner>();

    }

    //while the player is colliding with snow 
    void OnTriggerStay2D(Collider2D col)
    {

        //list to add to stuff we want to remove to avoid null elemnts in list error  
        List<GameObject> objectsToRemove = new List<GameObject>();


        //check if the tag is snow
        if (col.gameObject.CompareTag("Snow"))
        {
            //check if left mouse button is pressed 
            if (Input.GetKey(KeyCode.Mouse0))
            {
                foreach (GameObject bs in snowSpawner.objList)
                {
                    //make sure the snow is blue by using its tag
                    if (bs.CompareTag("Snow") && bs == col.gameObject && bs != null)
                    {

                        objectsToRemove.Add(bs);

                        //Score logic

                        //increase the limit of max spawned so more can be spawned
                        snowSpawner.maxSpawnLimit++;

                        //Score for regular shovel 
                        if (BuyItems.regShovelActive == true)
                        {
                            score += 150;
                            scoreText.text = score.ToString();
                        }

                        //Score for gold shovel 
                        if (BuyItems.goldShovelActive == true)
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
            }
        }

        //check if the tag is red snow 
        if (col.gameObject.CompareTag("RedSnow"))
        {
            //check if left mouse button is pressed 
            if (Input.GetKey(KeyCode.Mouse0))
            {
                foreach (GameObject rs in snowSpawner.objList)
                {
                    //make sure the snow is red by using its tag
                    if (rs.CompareTag("RedSnow") && rs == col.gameObject && rs != null)
                    {

                        objectsToRemove.Add(rs);

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
            }
        }

        //check if the tag is yellow snow 
        if (col.gameObject.CompareTag("YellowSnow"))
        {
            //check if left mouse button is pressed 
            if (Input.GetKey(KeyCode.Mouse0))
            {
                foreach (GameObject ys in snowSpawner.objList)
                {
                    //make sure the snow is yellow by using its tag
                    if (ys.CompareTag("YellowSnow") && ys == col.gameObject && ys != null)
                    {
   
                        objectsToRemove.Add(ys);

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
        }


        //delete the objects in the list 
        foreach (GameObject objToRemove in objectsToRemove)
        {
            snowSpawner.objList.Remove(objToRemove);
            Destroy(objToRemove);

        }



    }

    //If the blue elixir (Nuke) was used 
    void BlueElixirNuke()
    {


        //list to add to stuff we want to remove to avoid null elemnts in list error  
        List<GameObject> objectsToRemove = new List<GameObject>();


        //for each snow in the list 
        foreach (GameObject bs in snowSpawner.objList)
        {
            //make sure the snow is blue by using its tag
            if (bs.CompareTag("Snow"))
            {
                //to avoid errors
                if (bs != null)
                {
                    //Add the snow to the list of objects to be removed 
                    objectsToRemove.Add(bs);

                    //Score logic 

                    //increase the limit of max spawned so more can be spawned
                    snowSpawner.maxSpawnLimit++;

                    //Score for regular shovel 
                    if (BuyItems.regShovelActive == true)
                    {
                        score += 150;
                        scoreText.text = score.ToString();
                    }

                    //Score for gold shovel 
                    if (BuyItems.goldShovelActive == true)
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
        }


        //for each redsnow in the list 
        foreach (GameObject rs in snowSpawner.objList)
        {
            //make sure the snow is red by using its tag
            if (rs.CompareTag("RedSnow"))
            {
                if (rs != null)
                {
                    // Add the red snow to the list of objects to be removed
                    objectsToRemove.Add(rs);

                    //Score logic 

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
        }





        //for each yellow snow in the list 
        foreach (GameObject ys in snowSpawner.objList)
        {
            //make sure the snow is yellow by using its tag
            if (ys.CompareTag("YellowSnow"))
            {
                if (ys != null)
                {
                    // Add the yellow snow to the list of objects to be removed
                    objectsToRemove.Add(ys);

                    //Score logic 

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

        foreach (GameObject objToRemove in objectsToRemove)
        {
            snowSpawner.objList.Remove(objToRemove);
            Destroy(objToRemove);

        }




    }


    void Update()
    {
        
        //changing the image of both images when they are on delay, 
        if (Elixirs.blueElixirActive)
        {
            BlueElixirNuke();
        }
 
        bluecounter.text = "x" + BuyItems.blueElixirCounter.ToString();
        redCounter.text  = "x" + BuyItems.redElixirCounter.ToString();
        //this is so when we switch scenes the text also stays the same 
        scoreText.text = score.ToString();
        redScoreText.text = redScore.ToString();
        yellowScoreText.text = yellowScore.ToString();
    }



}
