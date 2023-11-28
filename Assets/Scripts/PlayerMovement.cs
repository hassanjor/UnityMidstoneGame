using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //position of player
    Vector3 pos;

    //reference to the player sprites and renderes 
    public SpriteRenderer spriteRenderer;
    public Sprite regShovelSprite;
    public Sprite goldShovelSprite; 

    // Update is called once per frame
    void Update()
    {
        //Rotation of character 

        //Get mouse position
        Vector3 mousePos = Input.mousePosition;
        //switch mouse position to character coordinates
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        // Calculate the direction from the player to the mouse position
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        //rotate the player according to the direction 
        transform.up = -direction;


        //Movement of character 

        //get the mouse position
        pos = Input.mousePosition;
        //switch mouse position to player coordinate
        pos = Camera.main.ScreenToWorldPoint(pos);
        //its 2D so we dont care about the Z
        pos.z = 0.0f;

        //lerp the player to the mouse
        //if we dont lerp the player will be bugged trying to rotate and move at the same time
        transform.position = Vector3.Lerp(transform.position, pos, 0.05f);


        //change the player sprite depending on what shove the player has bought 
        if(BuyItems.regShovelBought == true)
        {
            spriteRenderer.sprite = regShovelSprite;
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.0f);
        }

        if (BuyItems.goldShovelBought == true)
        {
            spriteRenderer.sprite = goldShovelSprite;
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.0f);
        }
    }

    
}
