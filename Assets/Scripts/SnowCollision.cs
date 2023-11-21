using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowCollision : MonoBehaviour
{
    //reference to the spawner of the snow
    public GameObject snow;
    SnowSpawner snowSpawner;

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
            }
        }

    }

}
