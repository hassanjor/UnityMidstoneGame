using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class BuyItems : MonoBehaviour
{
    //this is used to change stuff like the sprite of player, or score player gets
    //for reg shovel 
    public static bool regShovelActive;
    //for gold shovel 
    public static bool goldShovelActive;

    //this is made as a one time check to see if the shovel was ever bought in the first place, 
    //used to remove the "BUY" button and to dictate what shovel should have the "Equip" button 

    public static bool regBought;
    public static bool goldBought;
 

    //the buy buttons 
    public Button regShovelBuyBtn;
    public Button goldShovelBuyBtn; 


    //Equip Buttons
    public Button regShovelEquipButton;
    public Button goldShovelEquipButton;


    //Equipped Buttons
    public Button regShovelEquippedBtn;
    public Button goldShovelEquippedBtn;



    void Start()
    {
      
    }


    public void RegularShovelClicked()
    {
        //if the player presses the buy button for the regular shovel 
        //and has enough score then buy the shovel
        if(SnowCollision.score >= 2500)
        {
            //regular shovel is bought
            regBought = true;
            //reg shovel is active 
            regShovelActive = true;

            //make sure the gold shovel deactivates  (incase if the player had it before buying)
            goldShovelActive = false;

            //take away the price from the player 
            SnowCollision.score -= 2500;
            
        }
      
    }

    public void GoldShovelClicked()
    {
        //if the player presses the buy button for the gold shovel 
        //and has enough score then buy the shovel
        if (SnowCollision.redScore >= 1500)
        {
            //gold shovel bought 
            goldBought = true;
            //gold shovel is active
            goldShovelActive = true;

            //deactivate the regular shovel (incase if the player had it before buying)
            regShovelActive = false;

            //take away the price from the player 
            SnowCollision.redScore -= 1500; 
        }
    }

    //equipping the shovel with no cost, will get called on the equip button which only appears whne the shovel is bought anyways
    public void EquipRegularShovel()
    {
        regShovelActive = true;
        goldShovelActive = false;    
    }

    public void EquipGoldShovel()
    {
        goldShovelActive = true;
        regShovelActive = false;
    }



    void Update()
    {
        //Hide the buttons whenever they are done with 
        if (regShovelBuyBtn != null)
        {
            if (regBought == true)
            {
                regShovelBuyBtn.gameObject.SetActive(false);
                regShovelBuyBtn = null;

            }
        }
        if (goldShovelBuyBtn != null)
        {
            if (goldBought == true)
            {
                goldShovelBuyBtn.gameObject.SetActive(false);
                goldShovelBuyBtn = null;
            }
        }

        //if the regular shovel acive is true
        if (regShovelActive == true)
        {

            //disable the "EQUIP" button for regular shovel since it would be equipped now (if it was active)
            regShovelEquipButton.gameObject.SetActive(false);

            //Activate the regular shovel "Equipped"
            regShovelEquippedBtn.gameObject.SetActive(true);


            //disable the "EQUIPPED" button for the regular shovel since it is not equipped anymore if it was
            goldShovelEquippedBtn.gameObject.SetActive(false);

            if(goldBought == true)
            {
                goldShovelEquipButton.gameObject.SetActive(true);
            }
       
        }

        if (goldShovelActive == true)
        {

            //disable the "EQUIP" button for gold shovel since it would be equipped now 
            goldShovelEquipButton.gameObject.SetActive(false);

            //Activate the gold shovel "Equipped"
            goldShovelEquippedBtn.gameObject.SetActive(true);

            regShovelEquippedBtn.gameObject.SetActive(false);
            if (regBought == true)
            {
                regShovelEquipButton.gameObject.SetActive(true);
            }

        }

    }

}
