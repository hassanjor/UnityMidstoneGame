using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class BuyItems : MonoBehaviour
{
    //this is used to change stuff like the sprite of player, or score player gets
    //for reg shovel 
    public static bool regShovelBought;
    //for gold shovel 
    public static bool goldShovelBought; 


    //the buy button and its bool to determine when its active and not 
    public Button regShovelBuyBtn;
    static bool regShovelBuyBtnHide;

    public Button goldShovelBuyBtn; 
    static bool goldShovelBuyBtnHide;

    void Start()
    {
      
    }


    public void RegularShovelClicked()
    {
        //if the player presses the buy button for the regular shovel 
        //and has enough score then buy the shovel
        if(SnowCollision.score >= 2500)
        {
            goldShovelBought = false; 
            regShovelBought = true;
            regShovelBuyBtnHide = true;
            SnowCollision.score -= 2500;
            
        }
      
    }

    public void GoldShovelClicked()
    {
        //if the player presses the buy button for the gold shovel 
        //and has enough score then buy the shovel
        if (SnowCollision.redScore >= 1500)
        {
            regShovelBought = false; 
            goldShovelBought = true;
            goldShovelBuyBtnHide = true; 
            SnowCollision.redScore -= 1500; 
        }
    }

    void Update()
    {
        //Hide the buttons whenever they are done with 

        if (regShovelBuyBtnHide == true)
        {
            regShovelBuyBtn.gameObject.SetActive(false);
        }

        if (goldShovelBuyBtnHide == true)
        {
            goldShovelBuyBtn.gameObject.SetActive(false); 
        }
    }

}
