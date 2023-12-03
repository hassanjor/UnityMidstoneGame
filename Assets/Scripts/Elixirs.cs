using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }
}
