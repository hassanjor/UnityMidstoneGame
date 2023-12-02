using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elixirs : MonoBehaviour
{
    public static bool blueElixirActive;
    public static bool blueDelayOver;
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
        if(bTimer >= 0.1)
        {
            blueElixirActive = false;
        }


        
        
    }
}
