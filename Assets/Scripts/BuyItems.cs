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

    public static bool redSnowBought;
    public static bool yellowSnowBought;

    //counter for bought potions 
    public static int blueElixirCounter;
    public static int redElixirCounter;

    //text for the counter
    public Text blueElixirText;
    public Text redElixirText; 

    //the buy buttons 
    public Button regShovelBuyBtn;
    public Button goldShovelBuyBtn;
    public Button redSnowBuyBtn;
    public Button yellowSnowBuyBtn;
    public Button blueElixirBuyBtn;
    public Button redElixirBuyBtn;


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

    public void RedSnowClicked()
    {
        //if the player presses the buy button for red snow
        //and has enough score then buy red snow
        if (SnowCollision.score >= 500)
        {
            //red snow bought
            redSnowBought = true;

            //take away the price from the player 
            SnowCollision.score -= 500;
        }
    }

    public void YellowSnowClicked()
    {
        //if the player presses the buy button for yellow snow
        //and has enough score then buy yellow snow
        if (SnowCollision.redScore >= 100)
        {
            //yellow snow bought 
            yellowSnowBought = true;

            //take away the price from the player 
            SnowCollision.redScore -= 100;
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

    public void BlueElixirClicked()
    {
        if(SnowCollision.yellowScore >= 10 || SnowCollision.score >= 10 )
        {
            blueElixirCounter++;
            SnowCollision.yellowScore -= 10;
        }
    }

    public void RedElixirClicked()
    {
        if(SnowCollision.yellowScore >= 20 | SnowCollision.score >= 20)
        {
            redElixirCounter++;
            SnowCollision.yellowScore -= 20; 
        }
    }

    void Update()
    {
        //so it saves when switching scenes 
        blueElixirText.text = "x" + blueElixirCounter.ToString();
        redElixirText.text = "x" + redElixirCounter.ToString();


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

        if (redSnowBuyBtn!= null)
        {
            if (redSnowBought == true)
            {
                redSnowBuyBtn.gameObject.SetActive(false);
                redSnowBuyBtn = null;

            }
        }
        if (yellowSnowBuyBtn != null)
        {
            if (yellowSnowBought == true)
            {
                yellowSnowBuyBtn.gameObject.SetActive(false);
                yellowSnowBuyBtn = null;
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
