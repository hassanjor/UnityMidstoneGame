using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;

    void OnTriggerStay2D(Collider2D col)
    {
        //destroy the player if it ever collides with the lazer or spikes
        if (col.gameObject.CompareTag("Lazer") || (col.gameObject.CompareTag("Spike")))
        {
            Destroy(player);
            //this is where you will switch the scene to a you lost
            SceneManager.LoadScene("LoseGame");
        }


        if (col.gameObject.CompareTag("Boss"))
        {
            //check if left mouse button is pressed 
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Destroy(boss);
                //this is where you will switch the scene to a you win
                SceneManager.LoadScene("WinGame");

            }
        }



    }
}
