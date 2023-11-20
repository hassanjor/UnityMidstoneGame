using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 pos;

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
        pos.z = 1.0f;

        //lerp the player to the mouse
        //if we dont lerp the player will be bugged trying to rotate and move at the same time
        transform.position = Vector3.Lerp(transform.position, pos, 0.1f);
    }

    
}
