using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Elixirs : MonoBehaviour
{
    public static bool blueElixirActive;
    public static bool blueDelayOver;
    public static bool redElixirActive; 
    public static bool redDelayOver; 
    float bTimer;
    float rTimer; 
    static float blueDelayTimer;
    static float redDelayTimer;

    //images for UI 
    public Image blueElixir;
    public Image darkBlueElixir;
    public Image redElixir;
    public Image darkRedElixir; 



// Update is called once per frame
void Update()
    {
        //start both timers 
        blueDelayTimer += Time.deltaTime;
        bTimer += Time.deltaTime;
        redDelayTimer += Time.deltaTime;
        rTimer += Time.deltaTime;


        if (Input.GetKeyDown("1") && BuyItems.blueElixirCounter >= 1 && blueDelayOver)
        {
            bTimer = 0;
            blueElixirActive = true;
            BuyItems.blueElixirCounter--;

            //set up delay 
            blueDelayOver = false;
            blueDelayTimer = 0;
        }

        if(blueDelayTimer >= 5.0f) 
        {
            blueDelayOver = true;
            blueDelayTimer = 0.0f;
       
        }

        //time that the nuke is activted for
        if(bTimer >= 0.1f)
        {
            blueElixirActive = false;
        }

        if (Input.GetKeyDown("2") && BuyItems.redElixirCounter >= 1 && redDelayOver)
        {
            rTimer = 0.0f;
            redElixirActive = true;
            BuyItems.redElixirCounter--;

            //set up delay 
            redDelayOver = false;
            redDelayTimer = 0.0f;
        }
        //delay
        if(redDelayTimer >= 5.0f)
        {
            redDelayOver = true;
            redDelayTimer = 0.0f;
        }
        //time activated for
        if(rTimer >= 1.0f)
        {
            redElixirActive = false;
        }

        Debug.Log("elixer is active" + redElixirActive);
        Debug.Log(redDelayTimer);



        //changing the image of both images when they are on delay, 
        //these are to tell the player when they can use a potion and when they are on delay/dont have any
        if (blueElixirActive)
        {
            blueElixir.gameObject.SetActive(false);
            darkBlueElixir.gameObject.SetActive(true);
        }
        if (blueDelayOver && BuyItems.blueElixirCounter >= 1)
        {
            blueElixir.gameObject.SetActive(true);
            darkBlueElixir.gameObject.SetActive(false);
        }
        else
        {
            blueElixir.gameObject.SetActive(false);
            darkBlueElixir.gameObject.SetActive(true);

        }
        if (redElixirActive)
        {
            redElixir.gameObject.SetActive(false);
            darkRedElixir.gameObject.SetActive(true);
        }
        if (redDelayOver && BuyItems.redElixirCounter >= 1)
        {
            redElixir.gameObject.SetActive(true);
            darkRedElixir.gameObject.SetActive(false);
        }
        else
        {
            redElixir.gameObject.SetActive(false);
            darkRedElixir.gameObject.SetActive(true);

        }
    }
}
